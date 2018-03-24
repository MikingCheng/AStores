using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStores.Views;

namespace AStores.Services
{
    public class ShowSecondScreen
    {

        SecondWindow w2 = null;
        System.Windows.Forms.Screen s2 = null;

        public ShowSecondScreen()
        {
            if (System.Windows.Forms.Screen.AllScreens.Count() > 1)
            {
                w2 = new SecondWindow();
                s2 = System.Windows.Forms.Screen.AllScreens[1];
            }
        }

        public void ShowIt()
        {
            if (w2 != null && s2 != null)
            {
                Rectangle r2 = s2.WorkingArea;

                w2.Top = r2.Top;
                w2.Left = r2.Left;
                w2.Width = r2.Width;
                w2.Height = r2.Height;
                w2.Focusable = false;

                w2.Show();
            }
        }

}
}
