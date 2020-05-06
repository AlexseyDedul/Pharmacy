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
    public partial class Pharmacy : Form
    {
        private Аптека ph;
        public BindingList<Медикаменты> bdMedic;
        public BindingList<Заявки> bdApp;
        public BindingList<Медикаменты_в_заявке> bdMedApp;
        public BindingList<Накладные> bdInv;
        public BindingList<Медикаменты_в_накладной> bdMedInv;
        public BindingList<Медикаменты> med;
        public BindingList<Заявки> app;
        public BindingList<Накладные> inv;
        bool flag;
        bool flag2;

        public Pharmacy()
        {
            InitializeComponent();
            ph = new Аптека();
            bdMedic = new BindingList<Медикаменты>();
            bdApp = new BindingList<Заявки>();
            bdMedApp = new BindingList<Медикаменты_в_заявке>();
            bdInv = new BindingList<Накладные>();
            med = new BindingList<Медикаменты>();
            app = new BindingList<Заявки>();
            inv = new BindingList<Накладные>();
        }

        public void Update()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (!(flag2))
                {
                    bdMedic = new BindingList<Медикаменты>(ph.GetMed());
                    dataGridMed1.DataSource = bdMedic;
                    dataGridMed1.Columns[0].Width = 118;
                    dataGridMed1.Columns[1].Width = 200;
                    dataGridMed1.Columns[2].Width = 140;

                    dataGridMed1.Columns[0].HeaderText = "Дата";
                    dataGridMed1.Columns[1].HeaderText = "Наименование";
                    dataGridMed1.Columns[2].HeaderText = "Количество";
                }
                else
                {
                    if (!(flag))
                    {
                        dataGridMed1.DataSource = bdMedic;
                        dataGridMed1.Columns[0].Width = 118;
                        dataGridMed1.Columns[1].Width = 200;
                        dataGridMed1.Columns[2].Width = 140;

                        dataGridMed1.Columns[0].HeaderText = "Дата";
                        dataGridMed1.Columns[1].HeaderText = "Наименование";
                        dataGridMed1.Columns[2].HeaderText = "Количество";
                    }
                    else
                    {
                        dataGridMed1.DataSource = med;
                        dataGridMed1.Columns[0].Width = 118;
                        dataGridMed1.Columns[1].Width = 200;
                        dataGridMed1.Columns[2].Width = 140;

                        dataGridMed1.Columns[0].HeaderText = "Дата";
                        dataGridMed1.Columns[1].HeaderText = "Наименование";
                        dataGridMed1.Columns[2].HeaderText = "Количество";
                    }
                    flag2 = false;
                }
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (!(flag2))
                {
                    bdApp = new BindingList<Заявки>(ph.GetApp());
                    dataGridApp.DataSource = bdApp;
                    dataGridApp.Columns[0].Width = 118;
                    dataGridApp.Columns[1].Width = 160;
                    dataGridApp.Columns[2].Width = 140;

                    dataGridApp.Columns[0].HeaderText = "Дата";
                    dataGridApp.Columns[1].HeaderText = "Наименование";
                    dataGridApp.Columns[2].HeaderText = "Количество";
                }
                else
                {
                    if (!(flag))
                    {
                        dataGridApp.DataSource = bdApp;
                        dataGridApp.Columns[0].Width = 118;
                        dataGridApp.Columns[1].Width = 160;
                        dataGridApp.Columns[2].Width = 140;

                        dataGridApp.Columns[0].HeaderText = "Дата";
                        dataGridApp.Columns[1].HeaderText = "Наименование";
                        dataGridApp.Columns[2].HeaderText = "Количество";
                    }
                    else
                    {
                        dataGridApp.DataSource = app;
                        dataGridApp.Columns[0].Width = 118;
                        dataGridApp.Columns[1].Width = 160;
                        dataGridApp.Columns[2].Width = 140;

                        dataGridApp.Columns[0].HeaderText = "Дата";
                        dataGridApp.Columns[1].HeaderText = "Наименование";
                        dataGridApp.Columns[2].HeaderText = "Количество";
                    }
                    flag2 = false;
                }
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                if (!(flag2))
                {
                    bdInv = new BindingList<Накладные>(ph.GetInv());
                    dataGridInvoice.DataSource = bdInv;
                    dataGridInvoice.Columns[0].Width = 118;
                    dataGridInvoice.Columns[1].Width = 160;
                    dataGridInvoice.Columns[2].Width = 140;

                    dataGridInvoice.Columns[0].HeaderText = "Дата";
                    dataGridInvoice.Columns[1].HeaderText = "Наименование";
                    dataGridInvoice.Columns[2].HeaderText = "Количество";
                }
                else
                {
                    if (!(flag))
                    {
                        dataGridInvoice.DataSource = bdInv;
                        dataGridInvoice.Columns[0].Width = 118;
                        dataGridInvoice.Columns[1].Width = 160;
                        dataGridInvoice.Columns[2].Width = 140;

                        dataGridInvoice.Columns[0].HeaderText = "Дата";
                        dataGridInvoice.Columns[1].HeaderText = "Наименование";
                        dataGridInvoice.Columns[2].HeaderText = "Количество";
                    }
                    else
                    {
                        dataGridInvoice.DataSource = inv;
                        dataGridInvoice.Columns[0].Width = 118;
                        dataGridInvoice.Columns[1].Width = 160;
                        dataGridInvoice.Columns[2].Width = 140;

                        dataGridInvoice.Columns[0].HeaderText = "Дата";
                        dataGridInvoice.Columns[1].HeaderText = "Наименование";
                        dataGridInvoice.Columns[2].HeaderText = "Количество";
                    }
                    flag2 = false;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    ph.XmlDeserializable_med();
                    Update();
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    ph.XmlDeserializable_app();
                    Update();
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    ph.XmlDeserializable_inv();
                    Update();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Данного файла не существует, либо не было сохранения ранее");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (bdMedic.Count != 0)
                {
                    ph.XmlSerialize_med();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (bdApp.Count != 0)
                {
                    ph.XmlSerialize_app();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                if (bdInv.Count != 0)
                {
                    ph.XmlSerialize_inv();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }
        }

        public void add_med(Медикаменты med)
        {
            bdMedic.Add(med);
        }

        public void add_app(Заявки app)
        {
            bdApp.Add(app);
        }

        public BindingList<Заявки> get_app()
        {
            return bdApp;
        }

        public void add_inv(Накладные inv)
        {
            bdInv.Add(inv);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                AddMed addMed = new AddMed(this);
                addMed.Show();
                Update();
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                AddApp addApp = new AddApp(this);
                addApp.Show();
                Update();
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                AddInvoce addInv = new AddInvoce(this);
                addInv.Show();
                Update();
            }
        }

        private void dataGridApp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;

            Заявки medA = bdApp[i];

            bdMedApp = new BindingList<Медикаменты_в_заявке>(medA.GetMed_App());
            dataGridMedApp.DataSource = bdMedApp;
            dataGridMedApp.Columns[0].Width = 300;
            dataGridMedApp.Columns[1].Width = 160;

            dataGridMedApp.Columns[0].HeaderText = "Наименование";
            dataGridMedApp.Columns[1].HeaderText = "Количество";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    int index = dataGridMed1.CurrentCell.RowIndex;
                    bool edit = true;

                    AddMed AdM = new AddMed(this, index, edit, flag);
                    AdM.Show();
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    int ind = dataGridApp.CurrentCell.RowIndex;
                    bool edit2 = true;

                    AddApp AdA = new AddApp(this, ind, edit2, flag);
                    AdA.Show();
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    int ind = dataGridInvoice.CurrentCell.RowIndex;
                    bool edit2 = true;

                    AddInvoce AdI = new AddInvoce(this, ind, edit2, flag);
                    AdI.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите строку для редактирования");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    int index = dataGridMed1.CurrentCell.RowIndex;
                    if (!(flag))
                    {

                        bdMedic.RemoveAt(index);
                    }
                    else
                    {
                        bdMedic.Remove(med[index]);
                        med.RemoveAt(index);
                    }
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    int inde = dataGridApp.CurrentCell.RowIndex;
                    if (!(flag))
                    {
                        bdApp.RemoveAt(inde);
                    }
                    else
                    {
                        bdApp.Remove(app[inde]);
                        app.RemoveAt(inde);
                    }

                    if (dataGridApp.RowCount < 1)
                    {
                        dataGridMedApp.Columns.Clear();
                    }
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    int ind = dataGridInvoice.CurrentCell.RowIndex;
                    if (!(flag))
                    {
                        bdInv.RemoveAt(ind);
                    }
                    else
                    {
                        bdInv.Remove(inv[ind]);
                        inv.RemoveAt(ind);
                    }
                    if (dataGridInvoice.RowCount < 1)
                    {
                        dataGridMedInvoice.Columns.Clear();
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox MedSort = (ComboBox)sender;
            int sort = MedSort.SelectedIndex;

            if (sort == 0)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Медикаменты> medicSort = new List<Медикаменты>();
                    for (int i = 0; i < bdMedic.Count; i++)
                    {
                        medicSort.Add(bdMedic[i]);
                    }

                    bdMedic = new BindingList<Медикаменты>(ph.sort_medicDate(medicSort));
                    Update();
                }
                else
                {
                    List<Медикаменты> medicSort = new List<Медикаменты>();
                    for (int i = 0; i < med.Count; i++)
                    {
                        medicSort.Add(med[i]);
                    }

                    med = new BindingList<Медикаменты>(ph.sort_medicDate(medicSort));
                    Update();
                }
            }

            if (sort == 1)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Медикаменты> medicSort = new List<Медикаменты>();
                    for (int i = 0; i < bdMedic.Count; i++)
                    {
                        medicSort.Add(bdMedic[i]);
                    }

                    bdMedic = new BindingList<Медикаменты>(ph.sort_medic(medicSort));
                    Update();
                }
                else
                {
                    List<Медикаменты> medicSort = new List<Медикаменты>();
                    for (int i = 0; i < med.Count; i++)
                    {
                        medicSort.Add(med[i]);
                    }

                    med = new BindingList<Медикаменты>(ph.sort_medic(medicSort));
                    Update();
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (bdMedic.Count > 0)
            {
                med = new BindingList<Медикаменты>(bdMedic.Where(obj => obj.name.StartsWith(textBox1.Text)).ToList());
                dataGridMed1.DataSource = med;
                flag = true;
                if (textBox1.Text == "")
                {
                    Update();
                    flag = false;
                }
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

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (bdApp.Count > 0)
            {
                app = new BindingList<Заявки>(bdApp.Where(obj => obj.name.StartsWith(textBox2.Text)).ToList());
                dataGridApp.DataSource = app;
                flag = true;
                if (textBox2.Text == "")
                {
                    Update();
                    flag = false;
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Enter -= textBox2_Enter;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Поиск...";
                textBox2.Enter += textBox2_Enter;
                Update();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox AppSort = (ComboBox)sender;
            int sort = AppSort.SelectedIndex;

            if (sort == 0)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Заявки> AppSor = new List<Заявки>();
                    for (int i = 0; i < bdApp.Count; i++)
                    {
                        AppSor.Add(bdApp[i]);
                    }

                    bdApp = new BindingList<Заявки>(ph.sort_app_date(AppSor));
                    Update();
                }
                else
                {
                    List<Заявки> AppSor = new List<Заявки>();
                    for (int i = 0; i < app.Count; i++)
                    {
                        AppSor.Add(app[i]);
                    }

                    app = new BindingList<Заявки>(ph.sort_app_date(AppSor));
                    Update();
                }
            }

            if (sort == 1)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Заявки> AppSor = new List<Заявки>();
                    for (int i = 0; i < bdApp.Count; i++)
                    {
                        AppSor.Add(bdApp[i]);
                    }

                    bdApp = new BindingList<Заявки>(ph.sort_app_name(AppSor));
                    Update();
                }
                else
                {
                    List<Заявки> AppSor = new List<Заявки>();
                    for (int i = 0; i < app.Count; i++)
                    {
                        AppSor.Add(app[i]);
                    }

                    app = new BindingList<Заявки>(ph.sort_app_name(AppSor));
                    Update();
                }
            }
        }

        private void dataGridInvoice_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            Накладные medI = bdInv[i];
            bdMedInv = new BindingList<Медикаменты_в_накладной>(medI.GetMed_Inv());
            dataGridMedInvoice.DataSource = bdMedInv;
            dataGridMedInvoice.Columns[0].Width = 300;
            dataGridMedInvoice.Columns[1].Width = 160;

            dataGridMedInvoice.Columns[0].HeaderText = "Наименование";
            dataGridMedInvoice.Columns[1].HeaderText = "Количество";
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (bdInv.Count > 0)
            {
                inv = new BindingList<Накладные>(bdInv.Where(obj => obj.name.StartsWith(textBox3.Text)).ToList());
                dataGridInvoice.DataSource = inv;
                flag = true;
                if (textBox3.Text == "")
                {
                    Update();
                    flag = false;
                }
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Enter -= textBox3_Enter;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Поиск...";
                textBox3.Enter += textBox3_Enter;
                Update();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox InvSort = (ComboBox)sender;
            int sort = InvSort.SelectedIndex;

            if (sort == 0)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Накладные> InvSor = new List<Накладные>();
                    for (int i = 0; i < bdInv.Count; i++)
                    {
                        InvSor.Add(bdInv[i]);
                    }

                    bdInv = new BindingList<Накладные>(ph.sort_inv_date(InvSor));
                    Update();
                }
                else
                {
                    List<Накладные> InvSor = new List<Накладные>();
                    for (int i = 0; i < inv.Count; i++)
                    {
                        InvSor.Add(inv[i]);
                    }

                    inv = new BindingList<Накладные>(ph.sort_inv_date(InvSor));
                    Update();
                }
            }

            if (sort == 1)
            {
                flag2 = true;
                if (!(flag))
                {
                    List<Накладные> InvSor = new List<Накладные>();
                    for (int i = 0; i < bdInv.Count; i++)
                    {
                        InvSor.Add(bdInv[i]);
                    }

                    bdInv = new BindingList<Накладные>(ph.sort_inv_name(InvSor));
                    Update();
                }
                else
                {
                    List<Накладные> InvSor = new List<Накладные>();
                    for (int i = 0; i < inv.Count; i++)
                    {
                        InvSor.Add(inv[i]);
                    }

                    inv = new BindingList<Накладные>(ph.sort_inv_name(InvSor));
                    Update();
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    ph.XmlDeserializable_med();
                    Update();
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    ph.XmlDeserializable_app();
                    Update();
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    ph.XmlDeserializable_inv();
                    Update();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Данного файла не существует, либо не было сохранения ранее");
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (bdMedic.Count != 0)
                {
                    ph.XmlSerialize_med();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (bdApp.Count != 0)
                {
                    ph.XmlSerialize_app();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                if (bdInv.Count != 0)
                {
                    ph.XmlSerialize_inv();
                }
                else
                {
                    MessageBox.Show("Таблица не содержит данных");
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                AddMed addMed = new AddMed(this);
                addMed.Show();
                Update();
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                AddApp addApp = new AddApp(this);
                addApp.Show();
                Update();
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                AddInvoce addInv = new AddInvoce(this);
                addInv.Show();
                Update();
            }
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    int index = dataGridMed1.CurrentCell.RowIndex;
                    bool edit = true;

                    AddMed AdM = new AddMed(this, index, edit, flag);
                    AdM.Show();
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    int ind = dataGridApp.CurrentCell.RowIndex;
                    bool edit2 = true;

                    AddApp AdA = new AddApp(this, ind, edit2, flag);
                    AdA.Show();
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    int ind = dataGridInvoice.CurrentCell.RowIndex;
                    bool edit2 = true;

                    AddInvoce AdI = new AddInvoce(this, ind, edit2, flag);
                    AdI.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите строку для редактирования");
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    int index = dataGridMed1.CurrentCell.RowIndex;
                    if (!(flag))
                    {

                        bdMedic.RemoveAt(index);
                    }
                    else
                    {
                        bdMedic.Remove(med[index]);
                        med.RemoveAt(index);
                    }
                }

                if (tabControl1.SelectedTab == tabPage2)
                {
                    int inde = dataGridApp.CurrentCell.RowIndex;
                    if (!(flag))
                    {
                        bdApp.RemoveAt(inde);
                    }
                    else
                    {
                        bdApp.Remove(app[inde]);
                        app.RemoveAt(inde);
                    }
                }

                if (tabControl1.SelectedTab == tabPage3)
                {
                    int ind = dataGridInvoice.CurrentCell.RowIndex;
                    if (!(flag))
                    {
                        bdInv.RemoveAt(ind);
                    }
                    else
                    {
                        bdInv.Remove(inv[ind]);
                        inv.RemoveAt(ind);
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if ((bdMedic.Count != 0) && (bdApp.Count != 0) && (bdInv.Count != 0))
            {
                ph.XmlSerialize_med();
                ph.XmlSerialize_app();
                ph.XmlSerialize_inv();
            }
            else
            {
                MessageBox.Show("Таблица не содержит данных");
            }
        }

        private void сохранитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((bdMedic.Count != 0) && (bdApp.Count != 0) && (bdInv.Count != 0))
            {
                ph.XmlSerialize_med();
                ph.XmlSerialize_app();
                ph.XmlSerialize_inv();
            }
            else
            {
                MessageBox.Show("Таблица не содержит данных");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if ((bdMedic.Count > 0) && (bdInv.Count > 0) && (bdApp.Count > 0))
            {
                exportToHtml_med();
                exportToHtml_app();
                exportToHtml_inv();
                MessageBox.Show("Отчеты сформированы!");
            }
            else
            {
                MessageBox.Show("Заполните все поля для полной отчетности!");
            }
        }

        private void создатьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((bdMedic.Count > 0) && (bdInv.Count > 0) && (bdApp.Count > 0))
            {
                exportToHtml_med();
                exportToHtml_app();
                exportToHtml_inv();
                MessageBox.Show("Отчеты сформированы и сохранены в файл!");
            }
            else
            {
                MessageBox.Show("Заполните все поля для полной отчетности!");
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (bdMedic.Count > 0)
                {
                    string m;
                    int i = dataGridMed1.CurrentCell.RowIndex;
                    string a = "Медикаменты";
                    m = exportToHtml_med();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Выберите строку для отчетности!");
                }
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (bdApp.Count > 0)
                {
                    string m;
                    int i = dataGridApp.CurrentCell.RowIndex;
                    string a = bdApp[i].name;
                    m = exportToHtml_app();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Выберите строку для отчетности!");
                }
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                if (bdInv.Count > 0)
                {
                    string m;
                    int i = dataGridInvoice.CurrentCell.RowIndex;
                    string a = bdInv[i].name;
                    m = exportToHtml_inv();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Выберите строку для отчетности!");
                }
            }
        }

        private void полныйОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (bdMedic.Count > 0)
                {
                    string m;
                    int i = dataGridMed1.CurrentCell.RowIndex;
                    string a = "Медикаменты";
                    m = exportToHtml_med();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Заполните все поля для отчетности!");
                }
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (bdApp.Count > 0)
                {
                    string m;
                    int i = dataGridApp.CurrentCell.RowIndex;
                    string a = bdApp[i].name;
                    m = exportToHtml_app();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Заполните все поля для отчетности!");
                }
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                if (bdInv.Count > 0)
                {
                    string m;
                    int i = dataGridInvoice.CurrentCell.RowIndex;
                    string a = bdInv[i].name;
                    m = exportToHtml_inv();
                    Exp s = new Exp(m, a);
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Заполните все поля для отчетности!");
                }
            }
        }

        private void dataGridMed1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = dataGridMed1.CurrentCell.RowIndex;
                bool edit = true;

                AddMed AdM = new AddMed(this, index, edit, flag);
                AdM.Show();
            }
            catch (NullReferenceException)
            {
            }
        }

        private void dataGridApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int ind = dataGridApp.CurrentCell.RowIndex;
                bool edit2 = true;

                AddApp AdA = new AddApp(this, ind, edit2, flag);
                AdA.Show();
            }
            catch (NullReferenceException)
            {
            }
        }

        private void dataGridInvoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int ind = dataGridInvoice.CurrentCell.RowIndex;
                bool edit2 = true;

                AddInvoce AdI = new AddInvoce(this, ind, edit2, flag);
                AdI.Show();

            }
            catch (NullReferenceException)
            {
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информационная система 'Больничная аптека'\nРазработчик: Дедюль Алексей\nГруппа П31");
        }

        private void dataGridMedApp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int i = dataGridMedApp.CurrentCell.RowIndex;
                    int j = dataGridApp.CurrentCell.RowIndex;

                    bdMedApp.RemoveAt(i);
                    bdApp[j].number -= 1;
                }
                catch (NullReferenceException) { }
            }
        }

        private void dataGridMedInvoice_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int i = dataGridMedInvoice.CurrentCell.RowIndex;
                    int j = dataGridInvoice.CurrentCell.RowIndex;

                    bdMedInv.RemoveAt(i);
                    bdInv[j].number -= 1;
                }
            }
            catch (NullReferenceException) { }
        }

        public string exportToHtml_med()
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<meta http-equiv=\'Content-Type\' content=\'text/html; charset = utf-8\'>");
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<body>");

            strHTMLBuilder.Append("<table align='center' width='650px' border='0px' style='border: 1px solid black; margin-top: 25px;' cellpadding='3px' cellspacing='3px'>");
            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align='center' colspan='3'>");
            strHTMLBuilder.Append("<b><font size='+1'> Медикаменты  </font></b>");
            strHTMLBuilder.Append("</td>");
            strHTMLBuilder.Append("</tr>");


            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align ='left'>");
            strHTMLBuilder.Append("Дата");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='center' width='500' cols='3'>");
            strHTMLBuilder.Append("Наименование");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='right' width='100'>");
            strHTMLBuilder.Append("Количество");
            strHTMLBuilder.Append("</td>");

            foreach (Медикаменты u in bdMedic)
            {
                strHTMLBuilder.Append("<tr>");
                strHTMLBuilder.Append("<td align ='left'>");
                strHTMLBuilder.Append(u.localDate);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("<td align='center' width='500' cols='3'>");
                strHTMLBuilder.Append(u.name);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("<td align='right' width='100'>");
                strHTMLBuilder.Append(u.numbers_m);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("</tr>");
            }

            strHTMLBuilder.Append("</table>");

            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            string pathToHtmlFile = Environment.CurrentDirectory + "\\Отчеты\\medic.html";
            System.IO.File.WriteAllText(pathToHtmlFile, Htmltext);
            return strHTMLBuilder.ToString();

        }

        public string exportToHtml_app()
        {
            int i = dataGridApp.CurrentCell.RowIndex;
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<meta http-equiv=\'Content-Type\' content=\'text/html; charset = utf-8\'>");
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<body>");

            strHTMLBuilder.Append("<table align='center' width='650px' border='0px' style='border: 1px solid black; margin-top: 25px;' cellpadding='3px' cellspacing='3px'>");
            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align='center' colspan='3'>");
            strHTMLBuilder.Append("<b><font size='+1'>Заявка  </font></b>");
            strHTMLBuilder.Append("</td>");
            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align='left'>");
            strHTMLBuilder.Append("Дата");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='right'>");
            strHTMLBuilder.Append("Название");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td>");
            strHTMLBuilder.Append(bdApp[i].localDate);
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='right'>");
            strHTMLBuilder.Append(bdApp[i].name);
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align ='left' colspan='3'>");
            strHTMLBuilder.Append("<b>Медикаменты:</b>");

            strHTMLBuilder.Append("<table align='center' width='650px' border='1px' rules='all' style='border: 1px solid black; margin-top: 1px;' cellpadding='3px' cellspacing='3px'>");

            strHTMLBuilder.Append("<td align='center' width='500' cols='3'>");
            strHTMLBuilder.Append("Наименование");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='center' width='100'>");
            strHTMLBuilder.Append("Количество");
            strHTMLBuilder.Append("</td>");

            foreach (Медикаменты_в_заявке u in bdApp[i].med_app)
            {
                strHTMLBuilder.Append("<tr>");
                strHTMLBuilder.Append("<td>");
                strHTMLBuilder.Append(u.medicines);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("<td>");
                strHTMLBuilder.Append(u.numbers);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("</tr>");
            }

            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</table>");

            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            string pathToHtmlFile = Environment.CurrentDirectory + "\\Отчеты\\app.html";
            System.IO.File.WriteAllText(pathToHtmlFile, Htmltext);
            return strHTMLBuilder.ToString();

        }

        public string exportToHtml_inv()
        {
            int i = dataGridInvoice.CurrentCell.RowIndex;
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<meta http-equiv=\'Content-Type\' content=\'text/html; charset = utf-8\'>");
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<body>");

            strHTMLBuilder.Append("<table align='center' width='650px' border='0px' style='border: 1px solid black; margin-top: 25px;' cellpadding='3px' cellspacing='3px'>");
            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align='center' colspan='3'>");
            strHTMLBuilder.Append("<b><font size='+1'>Накладная  </font></b>");
            strHTMLBuilder.Append("</td>");
            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align='left'>");
            strHTMLBuilder.Append("Дата");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='right'>");
            strHTMLBuilder.Append("Название");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td>");
            strHTMLBuilder.Append(bdInv[i].localDate);
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='right'>");
            strHTMLBuilder.Append(bdInv[i].name);
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<tr>");
            strHTMLBuilder.Append("<td align ='left' colspan='3'>");
            strHTMLBuilder.Append("<b>Медикаменты:</b>");

            strHTMLBuilder.Append("<table align='center' width='650px' border='1px' rules='all' style='border: 1px solid black; margin-top: 1px;' cellpadding='3px' cellspacing='3px'>");

            strHTMLBuilder.Append("<td align='center' width='500' cols='3'>");
            strHTMLBuilder.Append("Наименование");
            strHTMLBuilder.Append("</td>");

            strHTMLBuilder.Append("<td align='center' width='100'>");
            strHTMLBuilder.Append("Количество");
            strHTMLBuilder.Append("</td>");

            foreach (Медикаменты_в_накладной u in bdInv[i].med_inv)
            {
                strHTMLBuilder.Append("<tr>");
                strHTMLBuilder.Append("<td>");
                strHTMLBuilder.Append(u.medicines);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("<td>");
                strHTMLBuilder.Append(u.numbers);
                strHTMLBuilder.Append("</td>");

                strHTMLBuilder.Append("</tr>");
            }

            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</table>");

            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            string pathToHtmlFile = Environment.CurrentDirectory + "\\Отчеты\\inv.html";
            System.IO.File.WriteAllText(pathToHtmlFile, Htmltext);
            return strHTMLBuilder.ToString();
        }

        private void Pharmacy_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = new System.Windows.Forms.DialogResult();
            result = MessageBox.Show("Желаете сохранить?", "Сохранение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                if (bdMedic.Count != 0)
                {
                    ph.XmlSerialize_med();
                }
                else
                {
                    MessageBox.Show("Таблица медикаментов не содержит данных");
                }
                
                if (bdApp.Count != 0)
                {
                    ph.XmlSerialize_app();
                }
                else
                {
                    MessageBox.Show("Таблица заявок не содержит данных");
                }
                
                if (bdInv.Count != 0)
                {
                    ph.XmlSerialize_inv();
                }
                else
                {
                    MessageBox.Show("Таблица накладных не содержит данных");
                }
                
            }

            var result2 = new System.Windows.Forms.DialogResult();
            result2 = MessageBox.Show("Вы действительно хотите выйти ?", "Выход",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result2 == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dataGridApp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridApp.CurrentCell.RowIndex;

                Заявки medA = bdApp[i];

                bdMedApp = new BindingList<Медикаменты_в_заявке>(medA.GetMed_App());
                dataGridMedApp.DataSource = bdMedApp;
                dataGridMedApp.Columns[0].Width = 300;
                dataGridMedApp.Columns[1].Width = 160;

                dataGridMedApp.Columns[0].HeaderText = "Наименование";
                dataGridMedApp.Columns[1].HeaderText = "Количество";
            }
            catch (NullReferenceException)
            {
            }
        }

        private void dataGridInvoice_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridInvoice.CurrentCell.RowIndex;
                Накладные medI = bdInv[i];
                bdMedInv = new BindingList<Медикаменты_в_накладной>(medI.GetMed_Inv());
                dataGridMedInvoice.DataSource = bdMedInv;
                dataGridMedInvoice.Columns[0].Width = 300;
                dataGridMedInvoice.Columns[1].Width = 160;

                dataGridMedInvoice.Columns[0].HeaderText = "Наименование";
                dataGridMedInvoice.Columns[1].HeaderText = "Количество";
            }
            catch (NullReferenceException) { }
        }

        private void dataGridApp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int j = dataGridApp.CurrentCell.RowIndex;

                    bdApp.RemoveAt(j);

                    if (dataGridApp.RowCount < 1)
                    {
                        dataGridMedApp.Columns.Clear();
                    }
                }
            }
            catch (NullReferenceException) { }
        }

        private void dataGridInvoice_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int j = dataGridInvoice.CurrentCell.RowIndex;

                    bdInv.RemoveAt(j);
                }
                if (dataGridInvoice.RowCount < 1)
                {
                    dataGridMedInvoice.Columns.Clear();
                }
            }
            catch (NullReferenceException) { }
        }

        private void dataGridMed1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int j = dataGridMed1.CurrentCell.RowIndex;

                    bdMedic.RemoveAt(j);
                }
            }
            catch (NullReferenceException) { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }
    }
}
