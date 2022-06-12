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
    public partial class Form9 : Form
    {
        kompetenzia DelKompetenzia;
        public Form9(kompetenzia kompetenzia)
        {
            InitializeComponent();

            DelKompetenzia = kompetenzia;

            label2.Text += DelKompetenzia.nazvaine_kompetenzia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var kompetenzia = context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == DelKompetenzia.nazvaine_kompetenzia);

                context.kompetenzia.Remove(kompetenzia);

                context.SaveChanges();
            }

            this.Close();
        }
    }
}
