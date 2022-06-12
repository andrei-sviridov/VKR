﻿using System;
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
    public partial class Form7 : Form
    {
        kompetenzia[] kompetenzias;
        grupa[] grupas;
        public sotrudnik NaznachaemiSotrudnik;
        List<kompetenzia> NeedKompetenzias = new List<kompetenzia>();
        List<sotrudnik> NeedSotrudniks = new List<sotrudnik>();
        List<sotrudnik_kompetenzia> NeedSotrudnik_Kompetenzia = new List<sotrudnik_kompetenzia>();
        public Form7()
        {
            InitializeComponent();

            label1.Text = "Выбрано\nкомпетенций: 0" ;

            refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)//set your checkbox column index instead of 2
            {
                int cheker = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        cheker += 1;
                    }

                    label1.Text = "Выбрано\nкомпетенций:" + " " + cheker;
                }
            }
        }

        private void NaznachitButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[2].EditedFormattedValue) == true)
                {
                    string fio = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    int cunt = Convert.ToInt32( dataGridView2.Rows[i].Cells[0].Value);
                    using (VkrContext context = new VkrContext())
                    {
                        ////Ищет по фио и количестве совподений компетенций, если одинаковое фио и количество, то будет хуёво
                        //NaznachaemiSotrudnik = context.sotrudnik.FirstOrDefault(x => x.fio_sotrudnik == fio); 
                        var q = NeedSotrudniks.GroupBy(x => x).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();

                        foreach (var item in q)
                        {
                            if (fio == item.Element.fio_sotrudnik && cunt == item.Counter)
                            {
                                NaznachaemiSotrudnik = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == item.Element.id_sotrudnik);
                            }
                        }
                    }
                }
            }

            foreach (var c in this.Owner.Controls)
            {
                if (c is ComboBox)
                {
                    foreach (var item in ((ComboBox)c).Items)
                    {
                        if ((item as sotrudnik).id_sotrudnik == (NaznachaemiSotrudnik as sotrudnik).id_sotrudnik)
                        {
                            ((ComboBox)c).SelectedItem = item;
                        }
                    }
                }
            }

            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true)
                {
                    int eRowIndex = e.RowIndex;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (i != eRowIndex) 
                        {
                            dataGridView2.Rows[i].Cells[2].Value = false;
                        }
                    }
                }
            }
        }

        void refresh()
        {
            using (VkrContext context = new VkrContext())
            {
                kompetenzias = context.kompetenzia.ToArray();
                grupas = context.grupa.ToArray();
                int i = -1;
                foreach (var gr in grupas)
                {


                    //dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Rows.Add(null, gr.nazvanie_grupa);
                    i = i + 1;
                    //dataGridView1.Rows[i].Cells[0].Style.= ;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;

                    foreach (var kmp in kompetenzias)
                    {
                        if (kmp.id_grupa == gr.id_grupa)
                        {
                            //dataGridView1.Columns[0].Width = 50;
                            //dataGridView1.Columns[0].Visible = true;
                            dataGridView1.Rows.Add(null, kmp.nazvaine_kompetenzia);
                            i = i + 1;
                        }
                    }
                }
            }
        }

        private void AceptButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string EtaKompetenzia = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        NeedKompetenzias.Add(context.kompetenzia.FirstOrDefault(x => x.nazvaine_kompetenzia == EtaKompetenzia));
                    }
                }

                foreach (var item in NeedKompetenzias)
                {
                   NeedSotrudnik_Kompetenzia.AddRange(context.sotrudnik_kompetenzia.Where(x => x.id_kompetenzia == item.id_kompetenzia));
                }

                foreach (var item in NeedSotrudnik_Kompetenzia)
                {
                    NeedSotrudniks.Add(context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == item.id_sotrudnik));
                }


                    var q = NeedSotrudniks.GroupBy(x => x).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();

                foreach (var item in q)
                {
                    dataGridView2.Rows.Add(item.Counter,item.Element.fio_sotrudnik);
                }
                    
                
            }
        }
    }
}