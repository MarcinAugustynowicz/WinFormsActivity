using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityWinForms
{
    public class IdleNotifier
    {
        private Form form;
        private Timer timer;

        // following is a standard way of creating event handlers
        // but can be simply written like this: "public event EventHandler Inactive;"
        private event EventHandler idle;
        public event EventHandler Idle
        {
            add { idle += value; }
            remove { idle -= value; }
        }
        protected virtual void OnIdle()
        {
            idle?.Invoke(this, EventArgs.Empty);
        }

        public IdleNotifier(Form form, TimeSpan idleThreshold)
        {
            this.form = form;

            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = (int)idleThreshold.TotalMilliseconds;
            timer.Tick += Timer_Tick;

            // register monitored events on the form - all these events represent user activity
            // TODO: this is not complete, its just an example of how this can work
            form.MouseMove += Form_MouseMove;
            form.MouseClick += Form_MouseClick;
            form.Activated += Form_Activated;
            form.Deactivate += Form_Deactivate;
            form.KeyDown += Form_KeyDown;

            // I know that this is not enough to catch all move events, 
            // but that's why we have this testing project
            form.Move += Form_Move;
        }

        private void Form_Move(object sender, EventArgs e)
        {
            ResetTimer();
        }
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            ResetTimer();
        }
        private void Form_Deactivate(object sender, EventArgs e)
        {
            ResetTimer();
        }
        private void Form_Activated(object sender, EventArgs e)
        {
            ResetTimer();
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }

        private void ResetTimer()
        {
            timer.Stop();
            timer.Start();
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {   // there was no activity for specified period of time
            OnIdle();
        }
    }
}
