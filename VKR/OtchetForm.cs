using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class OtchetForm : Form
    {
        Form2 Parent_Form;
        List<sotrudnik> sotrudniks = new List<sotrudnik>();
        List<sotrudnik> rukovoditels = new List<sotrudnik>();
        List<sotrudnik> sotrudniksForOtchet = new List<sotrudnik>();
        List<zadacha> zadachas = new List<zadacha>();
        public OtchetForm(Form2 parent)
        {
            InitializeComponent();
            this.Parent_Form = parent;
            refresh();
        }

        private void SotrudnikiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void refresh()
        {

            using (VkrContext context = new VkrContext())
            {
                sotrudniks = context.sotrudnik.ToList();
                foreach (var item in sotrudniks)
                {
                    var s = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == item.rukovoditel_sotrudnik);
                    if (s != null && !rukovoditels.Contains(s))
                    {
                        rukovoditels.Add(s);
                    }
                }

                foreach (var kurovods in rukovoditels)
                {
                    SotrudnikiDataGridView.Rows.Add(null, kurovods.fio_sotrudnik);

                    foreach (var sotr in sotrudniks)
                    {
                        if (sotr.rukovoditel_sotrudnik == kurovods.id_sotrudnik)
                        {
                            SotrudnikiDataGridView.Rows.Add(null, sotr.fio_sotrudnik, kurovods.fio_sotrudnik);
                        }
                    }
                }

            }

        }

        private void OtchotButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                for (int i = 0; i < SotrudnikiDataGridView.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(SotrudnikiDataGridView.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string fio = SotrudnikiDataGridView.Rows[i].Cells[1].Value.ToString();
                        sotrudniksForOtchet.Add(context.sotrudnik.FirstOrDefault(x => x.fio_sotrudnik == fio));
                    }
                }

                foreach (var SFO in sotrudniksForOtchet)
                {
                    zadachas.AddRange(context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik));

                    int KolZadachas = zadachas.Count();
                    int KolNeGotovihZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha != "Завершена").Count();
                    int KolGotovihZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha == "Завершена").Count();
                    int KolVozvrashZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha == "Возвращена").Count();

                    OtchotDataGridView.Rows.Add(SFO.fio_sotrudnik, KolZadachas, KolGotovihZadachas, KolNeGotovihZadachas, KolVozvrashZadachas);
                    zadachas.Clear();
                }
            }
        }

        private void PDFButton_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);



            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
            PdfPTable table = new PdfPTable(OtchotDataGridView.Columns.Count) { WidthPercentage = 100 };
            var colWidthPercentages = new[] { 40f, 10f, 10f, 10f, 10f, 10f, 10f};
            table.SetWidths(colWidthPercentages);

            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(new Phrase("Отчёт по выбранным сотрудникам", font));

                cell.Colspan = OtchotDataGridView.Columns.Count;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы балы как заголовок
                cell.Border = 0;
                table.AddCell(cell);
                

                //Сначала добавляем заголовки таблицы
                for (int j = 0; j < OtchotDataGridView.Columns.Count; j++)
                {
                    cell = new PdfPCell(new Phrase(new Phrase(OtchotDataGridView.Columns[j].HeaderText, font)));
                    //Фоновый цвет (необязательно, просто сделаем по красивее)
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                //Добавляем все остальные ячейки
                for (int j = 0; j < OtchotDataGridView.Rows.Count; j++)
                {
                    for (int k = 0; k < OtchotDataGridView.Columns.Count; k++)
                    {
                        if (OtchotDataGridView.Rows[j].Cells[k].Value != null)
                        {
                            table.AddCell(new Phrase(OtchotDataGridView.Rows[j].Cells[k].Value.ToString(), font));
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

        private void ExcelButton_Click(object sender, EventArgs e)
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
            for (int i = 1; i < OtchotDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = OtchotDataGridView.Columns[i - 1].HeaderText;
            }
        }

        private void ReadToWorkSheet(Worksheet worksheet)
        {
            for (int i = 0; i < OtchotDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < OtchotDataGridView.Columns.Count; j++)
                {
                    if (OtchotDataGridView[j, i].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = OtchotDataGridView[j, i].Value.ToString();
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
            Parent_Form.Show();
            this.Close();
        }
    }
}
