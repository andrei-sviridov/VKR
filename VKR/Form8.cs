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
    public partial class Form8 : Form
    {
        Form2 Parent_Form;

        kompetenzia[] kompetenzias;
        grupa[] GroupKompetenzias;
        public Form8(Form2 parent)
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

        private void RefreshButton_Click(object sender, EventArgs e)//кнопка ок
        {
            refresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var myForm = new Form9(KompetentComboBox.SelectedItem as kompetenzia);
            myForm.Show();
        }

        void refresh()
        {
            KompetentComboBox.Items.Clear();
            GroupKompetentComboBox.Items.Clear();

            using (VkrContext context = new VkrContext())
            {
                kompetenzias = context.kompetenzia.ToArray();
                GroupKompetenzias = context.grupa.ToArray();
            }

            KompetentComboBox.Items.AddRange(kompetenzias);
            GroupKompetentComboBox.Items.AddRange(GroupKompetenzias);
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                var kompetenzia = new kompetenzia();

                kompetenzia.nazvaine_kompetenzia = NazvanieKompetentTextBox.Text;
                kompetenzia.opisanie_kompetenzia = OpisanieTextBox.Text;
                kompetenzia.id_grupa = context.grupa.FirstOrDefault(x => x.nazvanie_grupa == GroupKompetentComboBox.Text).id_grupa;

                if ((context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == kompetenzia.nazvaine_kompetenzia)) == null)
                {
                    context.kompetenzia.Add(kompetenzia);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Компетенция с таким названием уже существует");
                }
            }
        }

        private void KompetentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kompetenzia EtaKompetenzia;

            using (VkrContext context = new VkrContext())
            {
                EtaKompetenzia = KompetentComboBox.SelectedItem as kompetenzia;

                NazvanieKompetentTextBox.Text = EtaKompetenzia.nazvaine_kompetenzia;
                OpisanieTextBox.Text = EtaKompetenzia.opisanie_kompetenzia;
                GroupKompetentComboBox.Text = context.grupa.FirstOrDefault(x => x.id_grupa == EtaKompetenzia.id_grupa).nazvanie_grupa;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                kompetenzia EtaKompetenzia = KompetentComboBox.SelectedItem as kompetenzia;

                var kompetenzia = context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == EtaKompetenzia.nazvaine_kompetenzia);

                kompetenzia.nazvaine_kompetenzia = NazvanieKompetentTextBox.Text;
                kompetenzia.opisanie_kompetenzia = OpisanieTextBox.Text;
                kompetenzia.id_grupa = context.grupa.FirstOrDefault(x => x.nazvanie_grupa == GroupKompetentComboBox.Text).id_grupa;

                context.SaveChanges();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
