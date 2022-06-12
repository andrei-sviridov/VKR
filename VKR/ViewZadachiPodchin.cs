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

        public List<zadacha> zadachas;

        public List<zadacha> Zadachi;
        public ViewZadachiPodchinForm(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();

            sotrudnikRukovoditel = sotrudnik;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Описание";
            dataGridView1.Columns[2].HeaderText = "Дата завершения";
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[4].HeaderText = "Создатель";
            dataGridView1.Columns[5].HeaderText = "Исполнитель";
            dataGridView1.Columns[0].Width = 40;

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
                        zadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == podchin.id_sotrudnik || x.id_sotrudnik == podchin.id_sotrudnik).ToList();

                        
                        foreach (var zadacha in zadachas)
                        {
                            dataGridView1.Rows.Add(zadacha.id_zadacha, zadacha.opisanie_zadacha, zadacha.srok_ispolnenia_zadacha, zadacha.status_zadacha, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_sotrudnik).fio_sotrudnik, context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == zadacha.id_ispolnitel_zadacha).fio_sotrudnik);
                        }
                    }

                }


            }
        }
    }
}
