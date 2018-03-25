using AStores.ViewModel;
using System.Timers;
using System.Windows;

namespace AStores.Services
{
    public class UpdateScale
    {

        Timer Scaletimer;
        MainWindowViewModel vm;
        public UpdateScale(Window w)
        {
            vm = w.DataContext as MainWindowViewModel;
            Scaletimer = new Timer(1000);
            Scaletimer.Elapsed += vm.HandleTimer;
            Scaletimer.AutoReset = true;
            Scaletimer.Enabled = true;
        }

        public void TimerStart()
        {
            Scaletimer.Start();
        }
    }
}
