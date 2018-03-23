using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AStores.Views;

namespace AStores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"C:/Users/mike.zheng/source/repos/WpfAppEFC/WpfAppEFC/images/close.png", UriKind.Relative));
            SampleButton.Fill = ib;
            for (int i = 0; i < 5; i++)
            {
                System.Windows.Controls.Button newBtn = new Button();
                newBtn.Width = 100;
                newBtn.Content = i.ToString();
                newBtn.Name = "Button" + i.ToString();

                sp.Children.Add(newBtn);
            }

        }

        private void DownloadProduct_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new ItemManagement();
            pm.Show();
        }

        private void PriceModification_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new PriceManagement();
            pm.Show();

        }

        private void ProductOrganization_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new ItemOrganization();
            pm.Show();
        }

        private void TransactionReport_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new ReportView();
            pm.Show();
        }

        private void Configuration_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new Configuration();
            pm.Show();
        }

        private void Second_Click(object sender, RoutedEventArgs e)
        {
            Window pm = new SecondWindow();
            pm.Show();
        }
    }
}
