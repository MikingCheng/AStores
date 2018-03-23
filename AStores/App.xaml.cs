using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

using AStores.ViewModel;
using AStores.Views;
using AStores.SDLScale.Interface;
using AStores.SDLScale;
using AStores.Utilities;

namespace AStores
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        SecondWindow w2;
        System.Windows.Forms.Screen s2;
        private ObservableCollection<ToDoItem> todoLists = new ObservableCollection<ToDoItem>();
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            if (System.Windows.Forms.Screen.AllScreens.Count() > 1)
            {
                w2 = new SecondWindow();
                s2 = System.Windows.Forms.Screen.AllScreens[1];
            }

            LoadData();

            ISDLScale sdlScale = new ConSDLScale(ParameterManager.Instance.ComPort, ParameterManager.Instance.Baud);
            StartScale(sdlScale);
        }

        private void StartScale(ISDLScale scale)
        {
            scale.InitScale();
            throw new NotImplementedException();
        }

        public ObservableCollection<ToDoItem> TodoLists
        {
            get { return this.todoLists; }
            set { this.todoLists = value; }
        }
        private void LoadData()
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

            todoLists.Add(new ToDoItem { Name = "Shopping", Price = 2.21M });
            todoLists.Add(new ToDoItem { Name = "Laundry", Price = 3.21M });
            //           throw new NotImplementedException();
        }
    }
}
