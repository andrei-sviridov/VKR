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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            using (VkrContext context = new VkrContext())
            {
                sotrudnik sotrudnik = context.sotrudnik.FirstOrDefault(x => x.login_sotrudnik == textBox1.Text && x.parol_sotrudnik == textBox2.Text);

                if (sotrudnik != null)
                {
                    var myForm = new Form2(sotrudnik);
                    myForm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Не верное имя пльзователя или пароль");
                }
            }
        }
    }
}
