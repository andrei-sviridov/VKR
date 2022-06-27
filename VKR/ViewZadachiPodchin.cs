using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace VKR
{
    public partial class ViewZadachiPodchinForm : Form
    {
        public sotrudnik sotrudnikRukovoditel;

        Form2 Parent_Form;

        public List<sotrudnik> podchins = new List<sotrudnik>();

        public List<zadacha> zadachas = new List<zadacha>();

        public List<zadacha> Zadachi;
        public ViewZadachiPodchinForm(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();
            this.Parent_Form = parent;
            sotrudnikRukovoditel = sotrudnik;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Описание задачи";
            dataGridView1.Columns[2].HeaderText = "Дата завершения задачи";
            dataGridView1.Columns[3].HeaderText = "Статус задачи";
            dataGridView1.Columns[4].HeaderText = "Создатель задачи";
            dataGridView1.Columns[5].HeaderText = "Исполнитель задачи";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(buttonColumn);
            buttonColumn.HeaderText = "Изменить задачу";
            buttonColumn.Text = "Изменить";

            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(buttonColumn2);
            buttonColumn2.HeaderText = "Журнал выполнения";
            buttonColumn2.Text = "Журнал";

            dataGridView1_RowsAdded(null, null);

            refresh();
        }

        public void refresh()
        {
            dataGridView1.Rows.Clear();
            podchins.Clear();
            zadachas.Clear();

            using (VkrContext context = new VkrContext())
            {
                podchins = context.sotrudnik.Where(x => x.rukovoditel_sotrudnik == sotrudnikRukovoditel.id_sotrudnik).ToList();

                foreach (var podchin in podchins)
                {
                    if (context.zadacha.Where(x => x.id_ispolnitel_zadacha == podchin.id_sotrudnik || x.id_sotrudnik == podchin.id_sotrudnik) != null)
                    {
                        zadachas.AddRange(context.zadacha.Where(x => x.id_ispolnitel_zadacha == podchin.id_sotrudnik || x.id_sotrudnik == podchin.id_sotrudnik).ToList());
                    }
                }

                var z = zadachas.ToArray();
                zadachas.Clear();
                var dtFrom = dateTimePicker1.Value;
                var dtTo = dateTimePicker2.Value;
                jurnal Jur = new jurnal();
                zadacha zad = new zadacha();
                foreach (var item in z)
                {
                    if (!zadachas.Contains(item))
                    {
                        //Jur = context.jurnal.FirstOrDefault(x => x.new_jurnal == "Назначена"  && x.data_jurnal<= dtTo && x.data_jurnal>= dtFrom && x.id_zadacha == item.id_zadacha);
                        //int idz = Jur.id_zadacha;
                        //zad = context.zadacha.FirstOrDefault(x => x.id_zadacha == idz);
                        if ((context.jurnal.FirstOrDefault(x => x.new_jurnal == "Назначена" && x.data_jurnal <= dtTo && x.data_jurnal >= dtFrom && x.id_zadacha == item.id_zadacha)) != null)
                        {
                            zadachas.Add(item);
                        }
                        
                    }
                }
                //zadachas.OrderBy(x => x.status_zadacha);
                zadachas = zadachas.OrderBy(x => x.id_ispolnitel_zadacha).ToList();
                var ToDayTime = DateTime.Now;
                int i = -1;
                foreach (var zadacha in zadachas)
                {
                    if (context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_ispolnitel_zadacha) != null)
                    {
                        dataGridView1.Rows.Add(zadacha.id_zadacha, zadacha.opisanie_zadacha, zadacha.srok_ispolnenia_zadacha, zadacha.status_zadacha, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_sotrudnik).fio_sotrudnik, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_ispolnitel_zadacha).fio_sotrudnik);
                        i = i + 1;
                        if (zadacha.status_zadacha != "Выполнена" && zadacha.srok_ispolnenia_zadacha < ToDayTime)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        var ZadachaJurnal = context.jurnal.Where(x => x.id_zadacha == zadacha.id_zadacha);
                        foreach (var itemZJ in ZadachaJurnal)
                        {
                            if (itemZJ.new_jurnal == "Выполнена" && itemZJ.data_jurnal >= zadacha.srok_ispolnenia_zadacha)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MediumVioletRed;
                            }
                        }
                    }
                    
                                      
                }


            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Columns.Count < 7) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var button = dataGridView1[6, i] as DataGridViewCell;
                button.Value = "Изменить";
            }

            if (dataGridView1.Columns.Count < 8) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var button2 = dataGridView1[7, i] as DataGridViewCell;
                button2.Value = "Журнал";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Parent_Form.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                zadacha EtaZadacha;
                int rowclick = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);

                if (e.ColumnIndex == 6)
                {
                    EtaZadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == rowclick);
                    var myForm = new Form6(2, EtaZadacha, sotrudnikRukovoditel, this);
                    myForm.Show();
                }

                List<jurnal> JurnalsZadach = new List<jurnal>();
                if (e.ColumnIndex == 7)
                {
                    EtaZadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == rowclick);
                    JurnalsZadach = context.jurnal.Where(x => x.id_zadacha == EtaZadacha.id_zadacha).ToList();

                    string messageText = "";

                    foreach (var item in JurnalsZadach)
                    {
                        messageText += Environment.NewLine + $"{item.data_jurnal} Статус задачи изменён с {item.old_jurnal} на {item.new_jurnal}";
                    }
                    MessageBox.Show(messageText);
                }
            }
        }

        private void ButtonPDF_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("Отчёт по задачам сотрудников.pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);



            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count - 2) { WidthPercentage = 100 };
            var colWidthPercentages = new[] { 5f, 25f, 14f, 16f, 20f, 20f};
            table.SetWidths(colWidthPercentages);

            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(new Phrase("Отчёт по задачам сотрудников", font));

            cell.Colspan = dataGridView1.Columns.Count - 2;
            cell.HorizontalAlignment = 1;
            //Убираем границу первой ячейки, чтобы балы как заголовок
            cell.Border = 0;
            table.AddCell(cell);


            //Сначала добавляем заголовки таблицы
            for (int j = 0; j < dataGridView1.Columns.Count - 2; j++)
            {
                cell = new PdfPCell(new Phrase(new Phrase(dataGridView1.Columns[j].HeaderText, font)));
                //Фоновый цвет (необязательно, просто сделаем по красивее)
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            //Добавляем все остальные ячейки
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count - 2; k++)
                {
                    if (dataGridView1.Rows[j].Cells[k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1.Rows[j].Cells[k].Value.ToString(), font));
                    }
                    else
                    {
                        table.AddCell(new Phrase("--", font));
                    }

                }
            }
            //Добавляем таблицу в документ
            doc.Add(table);

            //Закрываем документ
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            var app = new Application();
            Workbook workbook = app.Workbooks.Add(Type.Missing);
            Worksheet worksheet = workbook.ActiveSheet;
            app.Visible = true;
            ReadHeaderToWorkSheet(worksheet);
            ReadToWorkSheet(worksheet);
        }

        private void ReadHeaderToWorkSheet(Worksheet worksheet)
        {
            for (int i = 1; i < dataGridView1.Columns.Count -1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
        }

        private void ReadToWorkSheet(Worksheet worksheet)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count - 2; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
