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
        int flag;
        sotrudnik sotr;
        zadacha Zadacha;

        public Form Parent_Form;
        public Form6(int flag, zadacha zadacha, sotrudnik sotr, Form Parent_Form)
        {
            InitializeComponent();
            this.flag = flag;
            Zadacha = zadacha;
            this.sotr = sotr;

            this.Parent_Form = Parent_Form;

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
                numericUpDown1.ReadOnly = true;
                numericUpDown1.Enabled = false;
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
            //(this.Owner as Form5).refresh();//////////////////////

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

                var oldStatus = zadacha.status_zadacha;
                if (oldStatus != comboBox1.Text)
                {
                    jurnal jr = new jurnal();
                    jr.old_jurnal = oldStatus;
                    jr.new_jurnal = comboBox1.Text;
                    jr.id_zadacha = zadacha.id_zadacha;
                    jr.data_jurnal = DateTime.Now;
                    jr.id_sotrudnik = sotr.id_sotrudnik;
                    context.jurnal.Add(jr);
                }


                zadacha.opisanie_zadacha = textBox2.Text;
                zadacha.komentarii_zadacha = textBox3.Text;
                zadacha.status_zadacha = comboBox1.Text;
                DateTime dateTime = dateTimePicker1.Value;
                dateTime.AddHours(dateTimePicker2.Value.Hour);
                dateTime.AddMinutes(dateTimePicker2.Value.Minute);
                dateTime.AddSeconds(dateTimePicker2.Value.Second);
                zadacha.srok_ispolnenia_zadacha = dateTime;
                if((comboBox2.SelectedItem as sotrudnik)!= null)
                {
                    zadacha.id_ispolnitel_zadacha = (comboBox2.SelectedItem as sotrudnik).id_sotrudnik;
                }
                else
                {
                    zadacha.id_ispolnitel_zadacha = null;
                }
                

                zadacha.vaznost_zadacha = (int?)numericUpDown1.Value;

                context.SaveChanges();


                if (flag == 2)
                {
                    var mes = new Message();
                    mes.id_zadacha = zadacha.id_zadacha;
                    mes.id_sotrudnik = zadacha.id_sotrudnik;
                    mes.tekst_message = "Задача изменена руководителем";
                    context.Message.Add(mes);
                    context.SaveChanges();
                }

                if(comboBox1.Text == "Выполнена")
                {
                    var mes = new Message();
                    mes.id_zadacha = zadacha.id_zadacha;
                    mes.id_sotrudnik = zadacha.id_sotrudnik;
                    mes.tekst_message = "Задача выполнена";
                    context.Message.Add(mes);
                    context.SaveChanges();
                }
            }
            this.Close();
            Type t = Parent_Form.GetType();
            if (t.Name == "Form5")
            {
                (Parent_Form as Form5).refresh();
            }
            if (t.Name == "Form4")
            {
                (Parent_Form as Form4).refresh();
            }
            if (t.Name == "ViewZadachiPodchinForm")
            {
                (Parent_Form as ViewZadachiPodchinForm).refresh();
            }
            
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

                if (Zadacha.vaznost_zadacha != null)
                {
                    numericUpDown1.Value = (decimal)Zadacha.vaznost_zadacha;
                }
                

            }
        }

        private void vernytZadachy_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var zadacha = context.zadacha.FirstOrDefault(x => x.id_zadacha == Zadacha.id_zadacha);
                
                var oldStatus = zadacha.status_zadacha;

                zadacha.status_zadacha = "Возвращена";
                zadacha.id_ispolnitel_zadacha = null;

                context.SaveChanges();

                jurnal jr = new jurnal();
                jr.old_jurnal = oldStatus;
                jr.new_jurnal = "Возвращена";
                jr.id_zadacha = zadacha.id_zadacha;
                jr.data_jurnal = DateTime.Now;
                jr.id_sotrudnik = sotr.id_sotrudnik;
                context.jurnal.Add(jr);


                var mes = new Message();
                mes.id_zadacha = zadacha.id_zadacha;
                mes.id_sotrudnik = zadacha.id_sotrudnik;
                mes.tekst_message = "Задача возвращена";
                context.Message.Add(mes);
                context.SaveChanges();

                this.Close();
            }
        }
    }
}
