using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Appli : Form
    {
        Pharmacy ph;
        public BindingList<Заявки> bdApp2;
        public BindingList<Медикаменты_в_заявке> bdMedApp2;
        public Appli()
        {
            InitializeComponent();
        }

        public Appli(Pharmacy ph)
        {
            InitializeComponent();
            this.ph = ph;
            Update();

        }

        public void Update()
        {
            bdApp2 = new BindingList<Заявки>(ph.get_app());
            dataGridView1.DataSource = bdApp2;
            dataGridView1.Columns[0].Width = 118;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 110;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            Заявки medI = bdApp2[i];
            bdMedApp2 = new BindingList<Медикаменты_в_заявке>(medI.GetMed_App());
            dataGridView2.DataSource = bdMedApp2;
            dataGridView2.Columns[0].Width = 300;
            dataGridView2.Columns[1].Width = 140;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            BindingList<Заявки> app = new BindingList<Заявки>(bdApp2.Where(obj => obj.Name.StartsWith(textBox1.Text)).ToList());
            dataGridView1.DataSource = app;
            if (textBox1.Text == "")
            {
                Update();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enter -= textBox1_Enter;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Поиск...";
                textBox1.Enter += textBox1_Enter;
                Update();
            }
        }
    }
}
