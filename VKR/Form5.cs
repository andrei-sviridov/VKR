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

namespace VKR
{
    public partial class Form5 : Form
    {
        sotrudnik sotrudnikSozdatel;

        Form2 Parent_Form;

        List<zadacha> Zadachi;
        public Form5(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Описание задачи";
            dataGridView1.Columns[2].HeaderText = "Исполнитель задачи";
            dataGridView1.Columns[3].HeaderText = "Дата завершения задачи";
            dataGridView1.Columns[4].HeaderText = "Статус задачи";
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

            sotrudnikSozdatel = sotrudnik;

            this.Parent_Form = parent;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            Parent_Form.Show();
            this.Close();
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            timer_Tick(null, null);

            refresh();


        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Columns.Count < 6) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var button = dataGridView1[5, i] as DataGridViewCell;
                button.Value = "Изменить";
            }

            if (dataGridView1.Columns.Count < 7) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var button2 = dataGridView1[6, i] as DataGridViewCell;
                button2.Value = "Журнал";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                zadacha EtaZadacha;

                int rowclick = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);

                if (e.ColumnIndex == 5)
                {
                    EtaZadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == rowclick);
                    var myForm = new Form6(0, EtaZadacha, sotrudnikSozdatel, this);
                    //myForm.Owner = this;///////////////////////////////////////
                    myForm.Show();
                }

                
                List<jurnal> JurnalsZadach = new List<jurnal>();
                if (e.ColumnIndex == 6)
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

        public void refresh()
        {
            dataGridView1.Rows.Clear();

            using (VkrContext context = new VkrContext())
            {

                Zadachi = context.zadacha.Where(x => x.id_sotrudnik == sotrudnikSozdatel.id_sotrudnik).ToList();
                sotrudnik ZadachiIspolnitel;

                int i = -1;
                var ToDayTime = DateTime.Now;
                foreach (var zadach in Zadachi)
                {
                    ZadachiIspolnitel = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadach.id_ispolnitel_zadacha);
                    if (ZadachiIspolnitel != null)
                    {
                        dataGridView1.Rows.Add(zadach.id_zadacha, zadach.opisanie_zadacha, ZadachiIspolnitel.fio_sotrudnik, zadach.srok_ispolnenia_zadacha, zadach.status_zadacha);
                        i = i + 1;
                        if (zadach.status_zadacha != "Выполнена" && zadach.srok_ispolnenia_zadacha < ToDayTime)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        var ZadachaJurnal = context.jurnal.Where(x => x.id_zadacha == zadach.id_zadacha);
                        foreach (var itemZJ in ZadachaJurnal)
                        {
                            if (itemZJ.new_jurnal == "Выполнена" && itemZJ.data_jurnal >= zadach.srok_ispolnenia_zadacha)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MediumVioletRed;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add(zadach.id_zadacha, zadach.opisanie_zadacha, "--", zadach.srok_ispolnenia_zadacha, zadach.status_zadacha);
                        i = i + 1;
                        if (zadach.status_zadacha == "Возвращена")
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                    
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
