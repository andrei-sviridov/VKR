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
    public partial class Form12 : Form
    {
        Form2 Parent_Form;

        sotrudnik[] ispolniteli;
        public Form12(Form2 parent)
        {
            InitializeComponent();

            this.Parent_Form = parent;

            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parent_Form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var myForm = new Form2();
            //myForm.Show();
            //this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            using (VkrContext context = new VkrContext())
            {
                /////////////////////////////////////////////////////////////////////////////////////////////
            }
        }

        void refresh()
        {
            comboBox1.Items.Clear();

            using (VkrContext context = new VkrContext())
            {
                ispolniteli = context.sotrudnik.ToArray();
            }

            comboBox1.Items.AddRange(ispolniteli);
        }
    }
}
