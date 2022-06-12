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
    public partial class Form11 : Form
    {
        sotrudnik DelSotrudnik;
        public Form11(sotrudnik sotrudnik)
        {
            InitializeComponent();

            this.DelSotrudnik = sotrudnik;

            label2.Text += DelSotrudnik.fio_sotrudnik;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var sotrudnik = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == DelSotrudnik.id_sotrudnik);

                context.sotrudnik.Remove(sotrudnik);

                context.SaveChanges();
            }

            this.Close();
        }
    }
}
