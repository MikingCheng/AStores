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
        private decimal _total;
        private double _weight;

        public int ID { get; set; }

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

        public String Total
        {
            get { return this._total.ToString("0.##"); }
            //set
            //{
            //    this._total = value;
            //    OnPropertyChanged("Total");
            //}
        }

        public double  Weight
        {
            get { return this._weight ; }
            set
            {
                this._weight = value;
                _total = (decimal) _weight * _price;
                OnPropertyChanged("ToWeighttal");
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
