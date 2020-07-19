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
    public partial class AddApp : Form
    {
        Pharmacy ph;
        Заявки app;
        DateTime localDate = DateTime.Now;
        int index;
        bool edit;
        bool flag2;
        int m;
        int j;
        BindingList<Медикаменты_в_заявке> updateMedApp = new BindingList<Медикаменты_в_заявке>();
        public AddApp()
        {
            InitializeComponent();
            this.m = 0;
            this.j = 0;
        }

        public AddApp(Pharmacy ph, int index, bool edit, bool flag2)
        {
            InitializeComponent();
            this.ph = ph;
            this.index = index;
            this.edit = edit;
            this.flag2 = flag2;
            
        }

        public AddApp(Pharmacy ph)
        {
            this.ph = ph;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(edit))
            {
                app.Number = app.med_app.Count();
                ph.add_app(app);
                j = 0;
                textBox1.Text = "";
                textBox3.Text = "Введите медикаменты";
                textBox4.Text = "Введите количество";
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                if(!(flag2)) ph.bdMedApp = new BindingList<Медикаменты_в_заявке>(ph.bdApp[index].GetMed_App());
                else ph.bdMedApp = new BindingList<Медикаменты_в_заявке>(ph.app[index].GetMed_App());

                ph.dataGridMedApp.DataSource = ph.bdMedApp;
                ph.dataGridMedApp.Columns[0].Width = 300;
                ph.dataGridMedApp.Columns[1].Width = 160;

                ph.dataGridMedApp.Columns[0].HeaderText = "Наименование";
                ph.dataGridMedApp.Columns[1].HeaderText = "Количество";
                ph.Enabled = true;
                Hide();
            }
        }

        public void addMedicApp(Заявки app)
        {
            bool flag = true;
            for (int i = 0; i < app.med_app.Count; i++)
            {
                if (app.med_app[i].Medicines == textBox3.Text)
                {
                    app.med_app[i].Quantity += Convert.ToInt32(textBox4.Text);
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }

            if (flag)
            {
                app.add_medic_in_app(textBox3.Text, Convert.ToInt32(textBox4.Text));
                app.Number = app.med_app.Count();
                updateMedApp.Add(new Медикаменты_в_заявке(textBox3.Text, Convert.ToInt32(textBox4.Text)));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length <= 2) MessageBox.Show("Короткое название медикамента");
                if (textBox3.Text.Length >= 10) MessageBox.Show("Большое название медикамента");
                if (Convert.ToInt32(textBox4.Text) < 0) MessageBox.Show("Значение не может быть отрицательным");

                if (((textBox3.Text.Length > 2) && (textBox3.Text.Length < 10)) && (Convert.ToInt32(textBox4.Text) >= 0))
                {
                    if (!(edit))
                    {
                        addMedicApp(app);
                        label2.Text = "Медикамент №" + app.med_app.Count();
                        button1.Enabled = true;
                    }
                    else
                    {
                        if (!(flag2))
                        {
                            addMedicApp(ph.bdApp[index]);
                            label2.Text = "Медикамент №" + ph.bdApp[index].med_app.Count();
                        }
                        else
                        {
                            addMedicApp(ph.app[index]);
                            label2.Text = "Медикамент №" + ph.app[index].med_app.Count();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не правильно введено колличество!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 3) MessageBox.Show("Короткое название заявки");
            if (textBox1.Text.Length >= 30) MessageBox.Show("Большое название заявки");
            
            if ((textBox1.Text.Length > 3) && (textBox1.Text.Length < 30))
            {
                if (!(edit))
                {
                    app = new Заявки(localDate, textBox1.Text, 0);
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    j = j + 1;
                    label2.Text = "Медикамент №" + (m + 1);
                }
                else
                {
                    if (!(flag2))
                    {
                        ph.bdApp[index].Name = textBox1.Text;
                        label2.Text = "Медикамент №" + ph.bdApp[index].med_app.Count;
                    }
                    else
                    {
                        ph.app[index].Name = textBox1.Text;
                        label2.Text = "Медикамент №" + ph.app[index].med_app.Count;
                    }

                    button1.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                }
            }
        }

        private void AddApp_Load(object sender, EventArgs e)
        {
            ph.Enabled = false;
            if (edit)
            {
                if (!(flag2))
                {
                    label1.Text = "Дата: " + ph.bdApp[index].LocalDate;
                    textBox1.Text = ph.bdApp[index].Name;
                }
                else
                {
                    label1.Text = "Дата: " + ph.app[index].LocalDate;
                    textBox1.Text = ph.app[index].Name;
                }
            }
            else
            {
                label1.Text = "Дата: " + localDate;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox1.Text != "Введите название заявки"))
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            textBox1.Text = "Введите название заявки";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (!(flag2))
                {
                    for (int i = 0; i < ph.bdApp[index].med_app.Count(); i++)
                    {
                        for (int j = 0; j < updateMedApp.Count(); j++)
                        {
                            if (ph.bdApp[index].med_app[i].Medicines == updateMedApp[j].Medicines)
                            {
                                ph.bdApp[index].med_app.RemoveAt(i);
                                ph.bdApp[index].Number -= 1;
                            }
                        }
                    }
                }
            }


            ph.Enabled = true;
            Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && (textBox3.Text != "Введите медикамент"))
            {
                button3.Enabled = true;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = null;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == null)
                textBox3.Text = "Введите медикамент";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = null;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == null)
                textBox4.Text = "Введите количество";
        }

        private void AddApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (edit)
            {
                if (!(flag2))
                {
                    for (int i = 0; i < ph.bdApp[index].med_app.Count(); i++)
                    {
                        for (int j = 0; j < updateMedApp.Count(); j++)
                        {
                            if (ph.bdApp[index].med_app[i].Medicines == updateMedApp[j].Medicines)
                            {
                                ph.bdApp[index].med_app.RemoveAt(i);
                                ph.bdApp[index].Number -= 1;
                            }
                        }
                    }
                }
            }

            ph.Enabled = true;
            Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (((textBox4.Text != "") && (textBox4.Text != "Введите медикамент")))
            {
                button3.Enabled = false;
            }
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
        }
    }
}
