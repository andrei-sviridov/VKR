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
    public partial class ViewZadachiPodchinForm : Form
    {
        public sotrudnik sotrudnikRukovoditel;

        Form2 Parent_Form;

        public List<sotrudnik> podchins;

        public List<zadacha> zadachas = new List<zadacha>();

        public List<zadacha> Zadachi;
        public ViewZadachiPodchinForm(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();
            this.Parent_Form = parent;
            sotrudnikRukovoditel = sotrudnik;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Описание";
            dataGridView1.Columns[2].HeaderText = "Дата завершения";
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[4].HeaderText = "Создатель";
            dataGridView1.Columns[5].HeaderText = "Исполнитель";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(buttonColumn);
            buttonColumn.HeaderText = "Изменить";
            buttonColumn.Text = "Изменить"; ////????????????????????????

            dataGridView1_RowsAdded(null, null);

            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
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
                foreach (var item in z)
                {
                    if (!zadachas.Contains(item))
                    {
                        zadachas.Add(item);
                    }
                }

                foreach (var zadacha in zadachas)
                {
                    dataGridView1.Rows.Add(zadacha.id_zadacha, zadacha.opisanie_zadacha, zadacha.srok_ispolnenia_zadacha, zadacha.status_zadacha, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_sotrudnik).fio_sotrudnik, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_ispolnitel_zadacha).fio_sotrudnik);
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
                    var myForm = new Form6(2, EtaZadacha);
                    myForm.Show();
                }
            }
        }
    }
}
