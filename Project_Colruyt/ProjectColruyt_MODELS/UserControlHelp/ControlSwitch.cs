using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectColruyt_MODELS.UserControlHelp
{
     public delegate void ColruytDelegate(UserControl usc);
    public static class ControlSwitch
    {
        public static event ColruytDelegate UscEvent;

        public static void InvokeSwitch(UserControl usc)
        {
            UscEvent?.Invoke(usc);
        }
 
    }
}
