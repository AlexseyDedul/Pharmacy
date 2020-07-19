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
    public partial class AddInvoce : Form
    {
        Pharmacy ph;
        Накладные inv;
        DateTime localDate = DateTime.Now;
        int index;
        bool edit;
        bool flag2;
        bool fl;
        int m;
        int j;
        int sum;
        int summ;

        public AddInvoce()
        {
            InitializeComponent();
            this.m = 0;
            this.j = 0;
        }

        public AddInvoce(Pharmacy ph)
        {
            InitializeComponent();
            this.ph = ph;
            ph.Enabled = true;
        }

        public AddInvoce(Pharmacy ph, int index, bool edt, bool flag2)
        {
            InitializeComponent();
            this.ph = ph;
            this.index = index;
            this.edit = edt;
            this.flag2 = flag2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(edit))
            {
                inv = new Накладные(localDate, textBox1.Text, 0);
                j = j + 1;
                label2.Text = "Медикамент №" + m;
            }
            else
            {
                if (!(flag2))
                {
                    ph.bdInv[index].name = textBox1.Text;
                    ph.Update();
                    button3.Enabled = true;
                    ph.bdInv[index].number = ph.bdInv[index].med_inv.Count();
                }
                else
                {
                    ph.inv[index].name = textBox1.Text;
                    ph.Update();
                    button3.Enabled = true;
                    ph.inv[index].number = ph.inv[index].med_inv.Count();
                }
                
            }
            comboBox1.Enabled = true;
            textBox4.Enabled = true;
            button1.Enabled = true;
        }

        public void addMedInv(Накладные invoice)
        {
            bool flag = true;
            int i = comboBox1.SelectedIndex;
            sum = Convert.ToInt32(textBox4.Text);
            if (ph.bdMedic[i].numbers_m >= sum)
            {
                flag = true;
                for (int k = 0; k < invoice.med_inv.Count; k++)
                {
                    if (invoice.med_inv[k].Medicines == comboBox1.Text)
                    {
                        invoice.med_inv[k].Quantity += sum;
                        ph.bdMedic[i].numbers_m -= sum;
                        summ += sum;
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                        summ = sum;
                    }
                }

                if (flag)
                {
                    summ= sum;
                    invoice.add_medic_in_inv(comboBox1.Text, summ);
                    ph.bdMedic[i].numbers_m -= summ;
                    ph.Update();
                }
                label2.Text = "Медикамент №" + invoice.med_inv.Count();
            }
            else
            {
                MessageBox.Show("Такого количества медикаментов нет в аптеке!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(edit))
                {
                    addMedInv(inv);
                    button3.Enabled = true;
                }
                else
                {
                    if (!(flag2))
                    {
                        addMedInv(ph.bdInv[index]);
                        ph.bdInv[index].number = ph.bdInv[index].med_inv.Count();
                    }
                    else
                    {
                        addMedInv(ph.inv[index]);
                        ph.inv[index].number = ph.inv[index].med_inv.Count();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Не правильное введено колличество!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(edit))
            {
                inv.number = inv.med_inv.Count();
                ph.add_inv(inv);
                fl = false;
                textBox1.Text = "";
                textBox4.Text = "Введите количество";
                comboBox1.Enabled = false;
                textBox4.Enabled = false;
                button6.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                ph.Enabled = true;
                Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(edit))
            {
                if (fl)
                {
                    try
                    {
                        BindingList<Медикаменты_в_накладной> MInv = new BindingList<Медикаменты_в_накладной>();

                        MInv = new BindingList<Медикаменты_в_накладной>(inv.GetMed_Inv());

                        for (int i = 0; i < MInv.Count; i++)
                        {
                            for (int j = 0; j < ph.bdMedic.Count; j++)
                            {
                                if (MInv[i].Medicines == ph.bdMedic[j].name)
                                {
                                    ph.bdMedic[j].numbers_m += MInv[i].Quantity;
                                }
                            }
                        }
                        ph.Enabled = true;
                        Hide();
                    }
                    catch (NullReferenceException)
                    {
                        ph.Enabled = true;
                        Hide();
                    }
                }
                else
                {
                    ph.Enabled = true;
                    Hide();
                }
            }
            else
            {
                ph.Enabled = true;
                Hide();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
                textBox1.Text = "Введите название заявки";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = null;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == null)
                textBox4.Text = "Введите медикамент";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox4.Text != "") && (textBox4.Text != "Введите количество"))
            {
                button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox1.Text != "Введите название заявки"))
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
            if (((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            }
        }

        private void AddInvoce_Load(object sender, EventArgs e)
        {
            ph.Enabled = false;

            if (edit)
            {
                if (!(flag2))
                {
                    for (int i = 0; i < ph.bdMedic.Count; i++)
                    {
                        comboBox1.Items.Add(ph.bdMedic[i].name);
                        comboBox1.Text = ph.bdInv[index].med_inv[0].Medicines;
                    }
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                    label1.Text = "Дата: " + ph.bdInv[index].localDate;
                    textBox1.Text = ph.bdInv[index].name;
                }
                else
                {
                    for (int i = 0; i < ph.bdMedic.Count; i++)
                    {
                        comboBox1.Items.Add(ph.bdMedic[i].name);
                        comboBox1.Text = ph.inv[index].med_inv[0].Medicines;
                    }
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                    label1.Text = "Дата: " + ph.inv[index].localDate;
                    textBox1.Text = ph.inv[index].name;
                }
            }
            else
            {
                for (int i = 0; i < ph.bdMedic.Count; i++)
                {
                    comboBox1.Items.Add(ph.bdMedic[i].name);
                    comboBox1.Text = ph.bdMedic[0].name;
                }
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            label1.Text = "Дата: " + localDate;
        }

        private void AddInvoce_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(edit))
            {
                if (fl)
                {
                    try
                    {
                        BindingList<Медикаменты_в_накладной> MInv = new BindingList<Медикаменты_в_накладной>();

                        MInv = new BindingList<Медикаменты_в_накладной>(inv.GetMed_Inv());

                        for (int i = 0; i < MInv.Count; i++)
                        {
                            for (int j = 0; j < ph.bdMedic.Count; j++)
                            {
                                if (MInv[i].Medicines == ph.bdMedic[j].name)
                                {
                                    ph.bdMedic[j].numbers_m += MInv[i].Quantity;
                                }
                            }
                        }
                        ph.Enabled = true;
                        Hide();
                    }
                    catch (NullReferenceException)
                    {
                        ph.Enabled = true;
                        Hide();
                    }
                }
                else
                {
                    ph.Enabled = true;
                    Hide();
                }
            }
            else
            {
                ph.Enabled = true;
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Appli app = new Appli(ph);
            app.Show();
        }
    }
}
