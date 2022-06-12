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
            dataGridView1.Columns[1].HeaderText = "Описание";
            dataGridView1.Columns[2].HeaderText = "Исполнитель";
            dataGridView1.Columns[3].HeaderText = "Дата завершения";
            dataGridView1.Columns[4].HeaderText = "Статус";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(buttonColumn);
            buttonColumn.HeaderText = "Изменить";
            buttonColumn.Text = "Изменить"; ////????????????????????????

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
                    var myForm = new Form6(false, EtaZadacha);
                    myForm.Show();
                }
            }
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();

            using (VkrContext context = new VkrContext())
            {

                Zadachi = context.zadacha.Where(x => x.id_sotrudnik == sotrudnikSozdatel.id_sotrudnik).ToList();
                sotrudnik ZadachiIspolnitel;

                foreach (var zadach in Zadachi)
                {
                    ZadachiIspolnitel = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadach.id_ispolnitel_zadacha);
                    dataGridView1.Rows.Add(zadach.id_zadacha, zadach.opisanie_zadacha, ZadachiIspolnitel.fio_sotrudnik, zadach.srok_ispolnenia_zadacha, zadach.status_zadacha);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
