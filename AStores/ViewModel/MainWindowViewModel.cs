using System;
using System.Windows.Input;
using System.Timers;
using System.Windows;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AStores.Utilities;
using AStores.Services;
using AStores.SDLScale;

namespace AStores.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private decimal _weight = 17.0854m;
        public string Weight
        {
            get { return string.Format("{0:#.##}", _weight); }
            set
            { 
                _weight = System.Convert.ToDecimal(value);
                this.OnPropertyChanged("Weight");
            }
        }

        public  void HandleTimer(Object source, ElapsedEventArgs e)
        {
            Weight = (System.Convert.ToDecimal(Weight) + 0.53m) .ToString();
        }

        public ICommand WindowLoadCommand
        {
            get
            {
                return new RelayCommand(
                  param =>
                  {
//                      scale = new ConSDLScale();
                      UpdateScale wt = new UpdateScale(Application.Current.MainWindow);
                      wt.TimerStart();
                  },
                  null
                   );
            }
        }

    }
}
