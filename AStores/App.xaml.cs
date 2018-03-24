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
using AStores.Services;

namespace AStores
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        ShowSecondScreen _sndScreen = null;
        ISDLScale sdlScale = null;

        private ObservableCollection<ToDoItem> todoLists = new ObservableCollection<ToDoItem>();

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            ShowSndScreen();

            LoadData();

            sdlScale = new ConSDLScale(ParameterManager.Instance.ComPort, ParameterManager.Instance.Baud);
            StartScale(sdlScale);
        }

        private void ShowSndScreen()
        {
            _sndScreen = new ShowSecondScreen();
            _sndScreen.ShowIt();
            //throw new NotImplementedException();
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

            todoLists.Add(new ToDoItem { Name = "Shopping", Price = 2.21M });
            todoLists.Add(new ToDoItem { Name = "Laundry", Price = 3.21M });
            //           throw new NotImplementedException();
        }
    }
}
