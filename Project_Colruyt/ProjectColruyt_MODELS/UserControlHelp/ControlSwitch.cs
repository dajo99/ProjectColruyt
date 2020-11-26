using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectColruyt_MODELS.UserControlHelp
{
    public delegate void ColruytDelegate(UserControl usc, string title);
    //public delegate void ButtonVisibilityEvent(string visibility);

    public static class ControlSwitch
    {
        public static event ColruytDelegate UscEvent;
        //public static event ButtonVisibilityEvent ButtonVisibilityEvent;

        public static void InvokeSwitch(UserControl usc, string title)
        {
            UscEvent?.Invoke(usc, title);
        }

        //public static void SwitchVisibility(string visibility)
        //{
        //    ButtonVisibilityEvent?.Invoke(visibility);
        //}

    }
}
