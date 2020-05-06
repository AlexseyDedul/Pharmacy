using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class AddMed : Form
    {
        Pharmacy ph;
        DateTime localDate = DateTime.Now;
        int index;
        bool edit;
        bool flag;
        bool flag2;

        public AddMed()
        {
            InitializeComponent();
        }

        public AddMed(Pharmacy ph)
        {
            InitializeComponent();
            this.ph = ph;
            label1.Text = "Дата: " + localDate;
        }

        public AddMed(Pharmacy ph, int index, bool edit, bool flag2)
        {
            InitializeComponent();
            this.ph = ph;
            this.index = index;
            this.edit = edit;
            this.flag2 = flag2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            try
            {
                if (textBox1.Text.Length <= 2) MessageBox.Show("Короткое название медикамента");
                if (textBox1.Text.Length >= 10) MessageBox.Show("Большое название медикамента");
                if (Convert.ToInt32(textBox2.Text) < 0) MessageBox.Show("Значение не может быть отрицательным");
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox1.Text.Length > 2) && (textBox1.Text.Length < 10) && (Convert.ToInt32(textBox2.Text) >= 0))
                {
                    for (int i = 0; i < ph.bdMedic.Count; i++)
                    {
                        if (ph.bdMedic[i].name == textBox1.Text)
                        {
                            ph.bdMedic[i].numbers_m = ph.bdMedic[i].numbers_m + Convert.ToInt32(textBox2.Text);
                            ph.Update();
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
                        if (!(edit))
                        {
                            ph.add_med(new Медикаменты(localDate, textBox1.Text, Convert.ToInt32(textBox2.Text)));
                        }
                        else
                        {
                            if (!(flag2))
                            {
                                ph.bdMedic[index].localDate = localDate;
                                ph.bdMedic[index].name = textBox1.Text;
                                ph.bdMedic[index].numbers_m = Convert.ToInt32(textBox2.Text);
                                ph.Update();
                                ph.Enabled = true;
                                Hide();
                            }
                            else
                            {
                                ph.med[index].localDate = localDate;
                                ph.med[index].name = textBox1.Text;
                                ph.med[index].numbers_m = Convert.ToInt32(textBox2.Text);
                                ph.Update();
                                ph.Enabled = true;
                                Hide();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не правильное введено количество!");
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = null;
        }

        private void AddMed_Load(object sender, EventArgs e)
        {
            ph.Enabled = false;
            if (edit)
            {
                label1.Text = "Дата: " + ph.bdMedic[index].localDate;
                textBox1.Text = ph.bdMedic[index].name;
                textBox2.Text = Convert.ToString(ph.bdMedic[index].numbers_m);
            }

            if (flag2)
            {
                label1.Text = "Дата: " + ph.med[index].localDate;
                textBox1.Text = ph.med[index].name;
                textBox2.Text = Convert.ToString(ph.med[index].numbers_m);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ph.Enabled = true;
            Hide();
        }

        private void AddMed_FormClosed(object sender, FormClosedEventArgs e)
        {
            ph.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (((textBox1.Text != "") && (textBox1.Text != "Введите наименование")) && ((textBox2.Text != "") && (textBox2.Text != "Введите количество")))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }
    }
}
