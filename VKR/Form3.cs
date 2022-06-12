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
    public partial class Form3 : Form
    {
        sotrudnik[] ispolniteli;

        sotrudnik sotrudnikSozdatel;

        Form2 Parent_Form;
        public Form3(sotrudnik sotrudnik, Form2 parent)
        {
            InitializeComponent();
            //dateTimePicker2.Format = DateTimePickerFormat.Time;

            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.ShowUpDown = true;

            using (VkrContext context = new VkrContext())
            {
                ispolniteli = context.sotrudnik.ToArray();
            }

            comboBox1.Items.AddRange(ispolniteli);

            sotrudnikSozdatel = sotrudnik;

            this.Parent_Form = parent;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var zadacha = new zadacha();

                zadacha.id_sotrudnik = sotrudnikSozdatel.id_sotrudnik;

                zadacha.id_ispolnitel_zadacha = (comboBox1.SelectedItem as sotrudnik).id_sotrudnik;

                zadacha.opisanie_zadacha = textBox1.Text;

                zadacha.komentarii_zadacha = textBox2.Text;

                zadacha.vaznost_zadacha = (int)numericUpDown1.Value;

                DateTime dateTime = dateTimePicker1.Value;
                dateTime.AddHours(dateTimePicker2.Value.Hour);
                dateTime.AddMinutes(dateTimePicker2.Value.Minute);
                dateTime.AddSeconds(dateTimePicker2.Value.Second);
                zadacha.srok_ispolnenia_zadacha = dateTime;

                zadacha.status_zadacha = "Назначена";

                context.zadacha.Add(zadacha);
                context.SaveChanges();
            }


           
            Parent_Form.Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form7();
            myForm.Owner = this;
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Parent_Form.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
