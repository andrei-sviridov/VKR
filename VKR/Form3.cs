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
                jurnal jurnal = new jurnal();
                zadacha.id_sotrudnik = sotrudnikSozdatel.id_sotrudnik;

                if (comboBox1.SelectedItem != null)
                {
                    zadacha.id_ispolnitel_zadacha = (comboBox1.SelectedItem as sotrudnik).id_sotrudnik;
                    zadacha.status_zadacha = "Назначена";
                }
                else
                {
                    zadacha.status_zadacha = "Создана";
                }
                

                zadacha.opisanie_zadacha = textBox1.Text;

                zadacha.komentarii_zadacha = textBox2.Text;

                zadacha.vaznost_zadacha = (int)numericUpDown1.Value;

                DateTime dateTime = dateTimePicker1.Value;
                dateTime.AddHours(dateTimePicker2.Value.Hour);
                dateTime.AddMinutes(dateTimePicker2.Value.Minute);
                dateTime.AddSeconds(dateTimePicker2.Value.Second);
                zadacha.srok_ispolnenia_zadacha = dateTime;

                

                context.zadacha.Add(zadacha);
                
                context.SaveChanges();


                if (zadacha.status_zadacha == "Назначена")
                {
                    var zadacha2 = new zadacha();
                    zadacha2 = context.zadacha.FirstOrDefault(x => x.opisanie_zadacha == zadacha.opisanie_zadacha && x.id_ispolnitel_zadacha == zadacha.id_ispolnitel_zadacha && x.status_zadacha == zadacha.status_zadacha);
                    //&& x.id_ispolnitel_zadacha == zadacha.id_ispolnitel_zadacha && x.status_zadacha == "Назначена" && x.srok_ispolnenia_zadacha == zadacha.srok_ispolnenia_zadacha
                    jurnal.old_jurnal = "Создана";
                    jurnal.new_jurnal = "Назначена";
                    jurnal.data_jurnal = DateTime.Now;
                    jurnal.id_zadacha = zadacha2.id_zadacha;
                    jurnal.id_sotrudnik = sotrudnikSozdatel.id_sotrudnik;
                    context.jurnal.Add(jurnal);
                    context.SaveChanges();
                }


                if (comboBox1.SelectedItem != null)
                {
                    var mes = new Message();
                    mes.id_sotrudnik = (comboBox1.SelectedItem as sotrudnik).id_sotrudnik;
                    mes.tekst_message = "Назначена новая задача";
                    context.Message.Add(mes);
                    context.SaveChanges();
                }

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
