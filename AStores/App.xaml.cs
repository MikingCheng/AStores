using System.Collections.ObjectModel;
using System.Windows;
using AStores.SDLScale.Interface;
using AStores.Services;
using AStores.Utilities;
using AStores.ViewModel;
using AStores.SDLScale;

namespace AStores
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        ShowSecondScreen _sndScreen = null;

        private ObservableCollection<ToDoItem> todoLists = new ObservableCollection<ToDoItem>();

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            ShowSndScreen();

            LoadData();

        }

        private void ShowSndScreen()
        {
            _sndScreen = new ShowSecondScreen();
            _sndScreen.ShowIt();
            //throw new NotImplementedException();
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
