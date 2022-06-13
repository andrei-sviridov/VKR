using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR
{
    public partial class Form6 : Form
    {
        sotrudnik[] ispolniteli;

        zadacha Zadacha;
        public Form6(int flag, zadacha zadacha)
        {
            InitializeComponent();

            Zadacha = zadacha;

            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.ShowUpDown = true;

            if (flag == 1)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else if( flag == 0)
            {
                comboBox1.Enabled = false;
                vernytZadachy.Visible = false;
            }
            else if (flag == 2)
            {

            }

            refresh();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var zadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == Zadacha.id_zadacha);

                zadacha.opisanie_zadacha = textBox2.Text;
                zadacha.komentarii_zadacha = textBox3.Text;
                zadacha.status_zadacha = comboBox1.Text;  
                zadacha.id_ispolnitel_zadacha = (comboBox2.SelectedItem as sotrudnik).id_sotrudnik;

                context.SaveChanges();
            }
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refresh()
        {
            using (VkrContext context = new VkrContext())
            {
                ispolniteli = context.sotrudnik.ToArray();
                comboBox2.Items.AddRange(ispolniteli);


                textBox4.Text = Zadacha.sotrudnik.fio_sotrudnik;
                textBox2.Text = Zadacha.opisanie_zadacha;
                textBox3.Text = Zadacha.komentarii_zadacha;
                dateTimePicker1.Value = Zadacha.srok_ispolnenia_zadacha.Date;
                dateTimePicker2.Value = Zadacha.srok_ispolnenia_zadacha;
                comboBox1.Text = Zadacha.status_zadacha;
                comboBox2.SelectedItem = ispolniteli.FirstOrDefault(x => x.id_sotrudnik == Zadacha.id_ispolnitel_zadacha);


            }
        }

        private void vernytZadachy_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var zadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == Zadacha.id_zadacha);

                zadacha.status_zadacha = "Возвращена";
                zadacha.id_ispolnitel_zadacha = null;

                context.SaveChanges();
                this.Close();
            }
        }
    }
}
