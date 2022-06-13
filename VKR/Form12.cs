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
        sotrudnik ispolnitel;
        List<kompetenzia> kompetenzias = new List<kompetenzia>();
        List<kompetenzia> kompetenziasSotrudniks = new List<kompetenzia>();
        List<sotrudnik_kompetenzia> Sotrudnik_Kompetenzias = new List<sotrudnik_kompetenzia>();
        public Form12(Form2 parent)
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

        private void AceptButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string nazvKomp = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        kompetenzia Komp = context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == nazvKomp);
                        

                        if ((context.sotrudnik_kompetenzia.FirstOrDefault(x => x.id_kompetenzia == Komp.id_kompetenzia && x.id_sotrudnik == ispolnitel.id_sotrudnik)) != null)
                        {
                            sotrudnik_kompetenzia EtaSotrudnikKompetenzia = context.sotrudnik_kompetenzia.FirstOrDefault(x => x.id_kompetenzia == Komp.id_kompetenzia && x.id_sotrudnik == ispolnitel.id_sotrudnik);

                            if (dataGridView1.Rows[i].Cells[2].Value != null)
                            {
                                EtaSotrudnikKompetenzia.ozenka_sotrudnik_kompetenzia = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Оценка владения не выбрана");
                            }

                        }
                        else
                        {
                            if (dataGridView1.Rows[i].Cells[2].Value != null)
                            {
                                sotrudnik_kompetenzia EtaSotrudnikKompetenzia = new sotrudnik_kompetenzia();
                                EtaSotrudnikKompetenzia.id_sotrudnik = ispolnitel.id_sotrudnik;
                                EtaSotrudnikKompetenzia.id_kompetenzia = Komp.id_kompetenzia;
                                EtaSotrudnikKompetenzia.ozenka_sotrudnik_kompetenzia = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                                context.sotrudnik_kompetenzia.Add(EtaSotrudnikKompetenzia);
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Оценка владения не выбрана");
                            }

                        }
                    }
                    else
                    {
                        string nazvKomp = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        kompetenzia Komp = context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == nazvKomp);
                        if ((context.sotrudnik_kompetenzia.FirstOrDefault(x => x.id_kompetenzia == Komp.id_kompetenzia && x.id_sotrudnik == ispolnitel.id_sotrudnik)) != null)
                        {
                            sotrudnik_kompetenzia EtaSotrudnikKompetenzia = context.sotrudnik_kompetenzia.FirstOrDefault(x => x.id_kompetenzia == Komp.id_kompetenzia && x.id_sotrudnik == ispolnitel.id_sotrudnik);

                            context.sotrudnik_kompetenzia.Remove(EtaSotrudnikKompetenzia);
                            context.SaveChanges();
                        }
                    }
                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            using (VkrContext context = new VkrContext())
            {
                ispolnitel = comboBox1.SelectedItem as sotrudnik;

                foreach (var item in Sotrudnik_Kompetenzias)
                {
                    if ( item.id_sotrudnik == ispolnitel.id_sotrudnik)
                    {
                        kompetenziasSotrudniks.Add(context.kompetenzia.FirstOrDefault(x => x.id_kompetenzia == item.id_kompetenzia));
                    }
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    foreach (var item in kompetenziasSotrudniks)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == item.nazvaine_kompetenzia)
                        {
                            dataGridView1.Rows[i].Cells[0].Value = true;
                            dataGridView1.Rows[i].Cells[2].Value = (context.sotrudnik_kompetenzia.FirstOrDefault(x => x.id_kompetenzia == item.id_kompetenzia && x.id_sotrudnik == ispolnitel.id_sotrudnik).ozenka_sotrudnik_kompetenzia).ToString();
                        }
                    }

                }
            }
        }

        void refresh()
        {
            comboBox1.Items.Clear();

            using (VkrContext context = new VkrContext())
            {
                ispolniteli = context.sotrudnik.ToArray();

                kompetenzias = context.kompetenzia.ToList();

                Sotrudnik_Kompetenzias = context.sotrudnik_kompetenzia.ToList();
            }

            comboBox1.Items.AddRange(ispolniteli);

            dataGridView1.Rows.Clear();

            foreach (var item in kompetenzias)
            {
                dataGridView1.Rows.Add(null, item.nazvaine_kompetenzia);
            }
        }

        void ClearData()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = false;
                dataGridView1.Rows[i].Cells[2].Value = null;
            }

            kompetenziasSotrudniks.Clear();
        }
    }
}
