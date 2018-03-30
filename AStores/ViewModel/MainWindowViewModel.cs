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
        private string _connectedString;
        private string _total;

        public string TotalAmount
        {
            get
            {
                //return _toal;
                return ((App)Application.Current).TotalAmount;
            }
            set
            {
                _total = value;
                this.OnPropertyChanged("TotalAmount");

            }
        }
        public string Weight
        {
            get { return string.Format("{0:#.##}", _weight); }
            set
            { 
                _weight = System.Convert.ToDecimal(value);
                this.OnPropertyChanged("Weight");
            }
        }

        public string Name
        {
            get
            {
                return "大白菜";
            }
            set
            {
                Name = value;
                this.OnPropertyChanged("Name");

            }
        }
        public string Price
        {
            get { return "3.21"; }
            set
            {
                Name = value;
                this.OnPropertyChanged("Price");

            }
        }

        public string Connected
        {
            get { return _connectedString; }
            set
            {
                _connectedString = value;
                this.OnPropertyChanged("Connected");
            }
        }

        public  void HandleTimer(Object source, ElapsedEventArgs e)
        {
            if (ParameterManager.Instance.DemoScale == "Y")
            {
                Weight = (System.Convert.ToDecimal(Weight) + 0.53m).ToString();
            }
            else
               Weight = (sdlScale==null ? 0.0m : sdlScale.Weight).ToString();
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
 //               sdlScale.InitScale();
                if (sdlScale.InitScale())
                    Connected = "Connected";
                else
                    Connected = "Not Connect";

                return new RelayCommand(
                  param =>
                  {
                  },
                  null
               );
            }
        }

        public ICommand WindowClosedCommand
        {
            get
            {
                return new RelayCommand(
                  param =>
                  {
                      sdlScale.Close();
                  },
                  null
               );
            }
        }
        

    }
}
