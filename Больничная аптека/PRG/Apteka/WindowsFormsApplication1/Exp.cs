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
    public partial class Exp : Form
    {
        string P;
        string a;

        public Exp()
        {
            InitializeComponent();
        }

        public Exp(string P, string a)
        {
            InitializeComponent();
            this.P = P;
            this.a = a;
        }

        private void Exp_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = P;
            toolStripLabel1.Text = "Документ: "+ a +".html";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
