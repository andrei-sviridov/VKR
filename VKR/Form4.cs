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
    public partial class Form4 : Form
    {
        sotrudnik sotrudnikSozdatel;

        Form2 Parent_Form;

        List<zadacha> Zadachi;
        public Form4(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();

            sotrudnikSozdatel = sotrudnik;

            this.Parent_Form = parent;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Описание";
            dataGridView1.Columns[2].HeaderText = "Дата завершения";
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[4].HeaderText = "Создатель";
            dataGridView1.Columns[0].Width = 40;
            
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(buttonColumn);
            buttonColumn.HeaderText = "Изменить";
            buttonColumn.Text = "Изменить"; ////????????????????????????

            dataGridView1_RowsAdded(null, null);

           
        }

        void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString()+ " " + DateTime.Now.ToLongTimeString();

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            timer_Tick(null, null);

            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Parent_Form.Show();
            this.Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Columns.Count < 6) return;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               var button =  dataGridView1[5, i] as DataGridViewCell;
                button.Value = "Изменить";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (VkrContext context = new VkrContext()) 
            {
                zadacha EtaZadacha;
                int rowclick = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);

                if (e.ColumnIndex == 5)
                {
                    EtaZadacha = context.zadacha.FirstOrDefault(x=> x.id_zadacha == rowclick);
                    var myForm = new Form6(1, EtaZadacha);
                    myForm.Show();
                } 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            using (VkrContext context = new VkrContext())
            {

                Zadachi = context.zadacha.Where(x => x.id_ispolnitel_zadacha == sotrudnikSozdatel.id_sotrudnik).Include(x => x.sotrudnik).ToList();

                foreach (var zadacha in Zadachi)
                {
                    dataGridView1.Rows.Add(zadacha.id_zadacha, zadacha.opisanie_zadacha, zadacha.srok_ispolnenia_zadacha, zadacha.status_zadacha, zadacha.sotrudnik.fio_sotrudnik);
                }

            }
        }
    }
}
