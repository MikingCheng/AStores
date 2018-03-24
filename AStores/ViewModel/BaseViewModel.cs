using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AStores.ViewModel
{
  public class BaseViewModel: INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }

  }
}
