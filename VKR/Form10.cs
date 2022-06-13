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
    public partial class Form10 : Form
    {
        Form2 Parent_Form;

        sotrudnik[] ispolniteli;

        sotrudnik[] rukovoditeli;
        public Form10(Form2 parent)
        {
            InitializeComponent();

            this.Parent_Form = parent;

            refresh();

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            
            Parent_Form.Show();
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var myForm = new Form11(comboBox1.SelectedItem as sotrudnik);
            myForm.Show();

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    var sotrudnik = new sotrudnik();

                    sotrudnik.fio_sotrudnik = textBox1.Text;
                    sotrudnik.doljnost_sotrudnik = textBox2.Text;
                    sotrudnik.login_sotrudnik = textBox3.Text;
                    sotrudnik.parol_sotrudnik = textBox4.Text;
                    if (comboBox2.SelectedItem != null)
                    {
                        sotrudnik.rukovoditel_sotrudnik = (comboBox2.SelectedItem as sotrudnik).id_sotrudnik;
                    }
                    

                    if ((context.sotrudnik.FirstOrDefault(x => x.login_sotrudnik == sotrudnik.login_sotrudnik)) == null)
                    {
                        context.sotrudnik.Add(sotrudnik);
                        context.SaveChanges();
                        MessageBox.Show("Сотрудник добавлен");
                        refresh();
                        foreach (var item in comboBox1.Items)
                        {
                            if (item.ToString() == sotrudnik.fio_sotrudnik)
                            {
                                comboBox1.SelectedItem = item;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с такими данными уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля ФИО, Логин и Пароль");
                }

            }
        }

        void refresh()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            using (VkrContext context = new VkrContext())
            {
                ispolniteli = context.sotrudnik.ToArray();

                rukovoditeli = context.sotrudnik.Where(x => x.doljnost_sotrudnik.Contains("Руководитель")).ToArray();
            }

            comboBox1.Items.AddRange(ispolniteli);

            comboBox2.Items.AddRange(rukovoditeli);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sotrudnik EtotSotrudnik;

            using (VkrContext context = new VkrContext())
            {
                EtotSotrudnik = comboBox1.SelectedItem as sotrudnik;

                textBox1.Text = EtotSotrudnik.fio_sotrudnik;
                textBox2.Text = EtotSotrudnik.doljnost_sotrudnik;
                textBox3.Text = EtotSotrudnik.login_sotrudnik;
                textBox4.Text = EtotSotrudnik.parol_sotrudnik;
                
                if (context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == EtotSotrudnik.rukovoditel_sotrudnik) != null)
                {
                    comboBox2.Text = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == EtotSotrudnik.rukovoditel_sotrudnik).fio_sotrudnik.ToString();
                }
                else
                {
                    comboBox2.Text = "";
                }
                
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    sotrudnik EtotSotrudnik = comboBox1.SelectedItem as sotrudnik;

                    var sotrudnik = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == EtotSotrudnik.id_sotrudnik);

                    sotrudnik.fio_sotrudnik = textBox1.Text;
                    sotrudnik.doljnost_sotrudnik = textBox2.Text;
                    sotrudnik.login_sotrudnik = textBox3.Text;
                    sotrudnik.parol_sotrudnik = textBox4.Text;
                    if (comboBox2.SelectedItem != null)
                    {
                        sotrudnik.rukovoditel_sotrudnik = (comboBox2.SelectedItem as sotrudnik).id_sotrudnik;
                    }
                    

                    context.SaveChanges();
                    MessageBox.Show("Данные сотрудника изменены");
                    refresh();
                    foreach (var item in comboBox1.Items)
                    {
                        if (item.ToString() == sotrudnik.fio_sotrudnik)
                        {
                            comboBox1.SelectedItem = item;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля ФИО, Логин и Пароль");
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
