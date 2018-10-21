using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityWinForms
{
    class ActivityControllerBase
    {
        public event EventHandler<EventArgs> UserActive;
        public void ReportActivityEvent()
        {
            UserActive.Invoke(this, new EventArgs());
        }
    }
}
