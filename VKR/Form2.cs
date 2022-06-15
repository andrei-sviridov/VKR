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
    public partial class Form2 : Form
    {
        List<zadacha> Zadachi;
        List<Message> messages;

        sotrudnik sotrudnikSozdatel;
        public Form2(sotrudnik sotrudnik)
        {
            InitializeComponent();

            button7.Visible = false;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);



            sotrudnikSozdatel = sotrudnik;

            label1.Text = sotrudnikSozdatel.fio_sotrudnik;


            if (sotrudnikSozdatel.doljnost_sotrudnik != "HR" && sotrudnikSozdatel.doljnost_sotrudnik != "Руководитель")
            {
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                ViewZadachiPodchinButton.Visible = false;
                button10.Visible = false;

                button1.Height =  250;
                button2.Height = 250;
                button3.Height = 250;
            }
            else if (sotrudnikSozdatel.doljnost_sotrudnik != "Руководитель")
            {
                ViewZadachiPodchinButton.Visible = false;
                button10.Visible = false;
            }
            else if (sotrudnikSozdatel.doljnost_sotrudnik == "Руководитель")
            {
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                //ViewZadachiPodchinButton.Location.X = 12 ;
                //ViewZadachiPodchinButton.Location.Y = 191;
            }
         


            

        }
        void timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        void activ_Target()
        {
            textBox2.Clear();
            int countZadach = 0;

            using (VkrContext context = new VkrContext())
            {
                Zadachi = context.zadacha.Where(x => x.id_ispolnitel_zadacha == sotrudnikSozdatel.id_sotrudnik).ToList();

                foreach (var zadacha in Zadachi)
                {
                    countZadach += 1;
                }


            }
                textBox2.Text = "Текущих задач: " + countZadach + ";";
            using (VkrContext context = new VkrContext())
            {
                messages = context.Message.ToList();

                foreach (var item in messages)
                {
                    if (item.id_sotrudnik == sotrudnikSozdatel.id_sotrudnik)
                    {
                        textBox2.Text += Environment.NewLine + $"{item.id_zadacha} {item.tekst_message};";
                    }
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form3(sotrudnikSozdatel, this);
            myForm.Show();
            this.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form4(sotrudnikSozdatel, this);
            myForm.Show();
            this.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer_Tick(null, null);

            activ_Target();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myForm = new Form5(sotrudnikSozdatel, this);
            myForm.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new Form8(this);
            myForm.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var myForm = new Form10(this);
            myForm.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var myForm = new Form12(this);
            myForm.Show();
            this.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            activ_Target();
        }

        private void ViewZadachiPodchinButton_Click(object sender, EventArgs e)
        {
            var myForm = new ViewZadachiPodchinForm(sotrudnikSozdatel, this);
            myForm.Show();
            this.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var myForm = new OtchetForm(this);
            myForm.Show();
            this.Visible = false;
        }
    }
}
