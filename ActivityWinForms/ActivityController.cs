using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityWinForms
{
    class ActivityController :ActivityControllerBase
    {
        Timer mousetimer;//timer used for checking changes in mouse position
        Point lastpos;//updated mouse position
        int refreshrate = 1000;//refresh rate of mouse position checking
        Form form; 
        public ActivityController(Form form)
        {
            //InitializeComponent();
            //TargetWindowType = WindowType.Main;
            this.form = form;
            form.Activated += OnActivated;         
            form.KeyPreview = true;
            form.KeyDown += KeyDown;         
            mousetimer = new Timer();
            mousetimer.Tick += new EventHandler(MouseTimerLoop);
            mousetimer.Interval = refreshrate;
            mousetimer.Start();
        }        
        protected void OnActivated(object sender, EventArgs e)
        {
            //report activity when window is activated
            ReportActivity();
        }        
        void KeyDown(object sender, KeyEventArgs e)
        {
            //report activity when key is pressed
            ReportActivity();
        }        
        void MouseTimerLoop(object sender, EventArgs e)
        {
            //check if mouse position has changed, if so report activity and update mouse position
            if (lastpos != Cursor.Position)
            {
                ReportActivity();
            }
            lastpos = Cursor.Position;
        }
        void ReportActivity()
        {
            //if some form is active, send an event that user is active
            if (Form.ActiveForm != null)
            {
                ReportActivityEvent();
            }
        }        
    }
}
