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

            todoLists.Add(new ToDoItem { ID = 1, Name = "Apple", Price = 2.21M, Weight = 2.45 });
            todoLists.Add(new ToDoItem { ID = 2, Name = "Juice", Price = 3.21M, Weight = 3.45 });
            todoLists.Add(new ToDoItem { ID = 3, Name = "Cheey", Price = 5.21M, Weight = 4.45 });
            todoLists.Add(new ToDoItem { ID = 4, Name = "Blueberry", Price = 4.21M, Weight = 5.45 });
            //           throw new NotImplementedException();
        }
    }
}
