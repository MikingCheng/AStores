﻿using System;
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
using AStores.SDLScale;
using AStores.Utilities;
using AStores.Services;

namespace AStores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ConSDLScale sdlinft = null;
        //UpdateScale wt;


        public MainWindow()
        {
            InitializeComponent();

//            sdlinft = new ConSDLScale(ParameterManager.Instance.ComPort, ParameterManager.Instance.Baud);
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
            // 初始化皮重
            //if (sdlinft.InitScale())
            //    CoMM.Text = "Conected";
            //else
            //    CoMM.Text = "not-Conn";



            //ImageBrush ib = new ImageBrush();
            //ib.ImageSource = new BitmapImage(new Uri(@"C:/Users/mike.zheng/source/repos/WpfAppEFC/WpfAppEFC/images/close.png", UriKind.Relative));
            //SampleButton.Fill = ib;
            //for (int i = 0; i < 5; i++)
            //{
            //    System.Windows.Controls.Button newBtn = new Button();
            //    newBtn.Width = 100;
            //    newBtn.Content = i.ToString();
            //    newBtn.Name = "Button" + i.ToString();

            //    sp.Children.Add(newBtn);
            //}

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // 开始读取
 //           Weigh.Text = sdlinft.Weight.ToString();
            //wt = new UpdateScale(Application.Current.MainWindow);
            //wt.TimerStart();



            //if (objThread == null)
            //{
            //    objThread = new Thread(new ThreadStart(delegate
            //    {
            //        open = true;
            //        ThreadMethodTxt();
            //    }));
            //}
            //objThread.Start();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // 循环读取重量
            //sdlinft.ReadWeight();

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

        private void Window_Closed(object sender, EventArgs e)
        {
 //           sdlinft.Close();

        }
    }
}
