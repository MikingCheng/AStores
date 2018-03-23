using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStores.ViewModel
{
    public class TodoList
    {
        List<ToDoItem> MyList = new List<ToDoItem>
        {
            new ToDoItem {Name="Shopping", Price=2.21M  },
            new ToDoItem{Name="Laundry", Price=3.21M  }
        };
    }

    public class ToDoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private decimal _price;

        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                OnPropertyChanged("Name");
            }

        }
        public decimal Price
        {
            get { return this._price; }
            set
            {
                this._price = value;
                OnPropertyChanged("Price");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
