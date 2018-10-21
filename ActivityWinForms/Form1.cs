using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityWinForms
{
    public partial class Form1 : Form
    {
        ActivityController cont;
        public Form1()
        {
            InitializeComponent();
            cont = new ActivityController(this);
            cont.UserActive += msg;
        }
        public void msg(object sender,EventArgs e)
        {
            this.textBox1.AppendText("New activity reported " + DateTime.Now.ToString()+"\n");
        }
    }
}
