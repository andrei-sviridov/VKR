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
    public partial class OtchetForm : Form
    {
        Form2 Parent_Form;
        List<sotrudnik> sotrudniks = new List<sotrudnik>();
        List<sotrudnik> rukovoditels = new List<sotrudnik>();
        List<sotrudnik> sotrudniksForOtchet = new List<sotrudnik>();
        List<zadacha> zadachas = new List<zadacha>();
        public OtchetForm(Form2 parent)
        {
            InitializeComponent();
            this.Parent_Form = parent;
            refresh();
        }

        private void SotrudnikiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void refresh()
        {

            using (VkrContext context = new VkrContext())
            {
                sotrudniks = context.sotrudnik.ToList();
                foreach (var item in sotrudniks)
                {
                    var s = context.sotrudnik.FirstOrDefault(x => x.id_sotrudnik == item.rukovoditel_sotrudnik);
                    if (s != null && !rukovoditels.Contains(s))
                    {
                        rukovoditels.Add(s);
                    }
                }

                foreach (var kurovods in rukovoditels)
                {
                    SotrudnikiDataGridView.Rows.Add(null, kurovods.fio_sotrudnik);

                    foreach (var sotr in sotrudniks)
                    {
                        if (sotr.rukovoditel_sotrudnik == kurovods.id_sotrudnik)
                        {
                            SotrudnikiDataGridView.Rows.Add(null, sotr.fio_sotrudnik, kurovods.fio_sotrudnik);
                        }
                    }
                }

            }

        }

        private void OtchotButton_Click(object sender, EventArgs e)
        {
            using (VkrContext context = new VkrContext())
            {
                for (int i = 0; i < SotrudnikiDataGridView.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(SotrudnikiDataGridView.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string fio = SotrudnikiDataGridView.Rows[i].Cells[1].Value.ToString();
                        sotrudniksForOtchet.Add(context.sotrudnik.FirstOrDefault(x => x.fio_sotrudnik == fio));
                    }
                }

                foreach (var SFO in sotrudniksForOtchet)
                {
                    zadachas.AddRange(context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik));

                    int KolZadachas = zadachas.Count();
                    int KolNeGotovihZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha != "Завершена").Count();
                    int KolGotovihZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha == "Завершена").Count();
                    int KolVozvrashZadachas = context.zadacha.Where(x => x.id_ispolnitel_zadacha == SFO.id_sotrudnik && x.status_zadacha == "Возвращена").Count();

                    OtchotDataGridView.Rows.Add(SFO.fio_sotrudnik, KolZadachas, KolGotovihZadachas, KolNeGotovihZadachas, KolVozvrashZadachas);
                    zadachas.Clear();
                }
            }
        }

        private void PDFButton_Click(object sender, EventArgs e)
        {

        }

        private void ExcelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
