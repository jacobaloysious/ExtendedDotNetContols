using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoadOnScroll
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

        private void ItemsCountClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Number of Items in the List Box : {0}",this.listBox.Items.Count.ToString()), "Items count");
        }

        private void DataGridItemsCountClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Number of Items in the List Box : {0}", this.dataGrid.Items.Count.ToString()), "Items count");
        }

    }
}
