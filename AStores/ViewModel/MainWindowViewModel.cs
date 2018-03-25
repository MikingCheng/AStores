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
using AStores.SDLScale.Interface;

namespace AStores.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        ISDLScale sdlScale = null;

        private decimal _weight;
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
            if  (ParameterManager.Instance.DemoScale == "Y")
            {
                Weight = (System.Convert.ToDecimal(Weight) + 0.53m).ToString();
            }
            else
                Weight = sdlScale?.Weight.ToString();
        }

        public ICommand WindowLoadCommand
        {
            get
            {
                return new RelayCommand(
                   param =>
                      {
                          UpdateScale wt = new UpdateScale(Application.Current.MainWindow);
                          wt.TimerStart();
                      },
                      null
                );
            }
        }

        public ICommand WindowInitializedCommand
        {
            get
            {
                _weight = 17.0854m;
                sdlScale = new ConSDLScale(ParameterManager.Instance.ComPort, ParameterManager.Instance.Baud);
                sdlScale.InitScale();
                return new RelayCommand(
                  param =>
                  {
                  },
                  null
               );
            }
        }

    }
}
