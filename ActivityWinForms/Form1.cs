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
        IdleNotifier cont;
        public Form1()
        {
            InitializeComponent();
            cont = new IdleNotifier(this,TimeSpan.FromSeconds(3));
            cont.Idle += msg;
        }
        public void msg(object sender,EventArgs e)
        {
            this.textBox1.AppendText("User idle for 3 seconds " + DateTime.Now.ToString()+"\n");
        }
    }
}
