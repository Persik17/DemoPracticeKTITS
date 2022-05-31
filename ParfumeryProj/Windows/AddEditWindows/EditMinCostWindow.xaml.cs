using ParfumeryProj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ParfumeryProj.Windows.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для EditMinCostWindow.xaml
    /// </summary>
    public partial class EditMinCostWindow : Window
    {
        private static List<Product> localProducts = new List<Product>();
        public EditMinCostWindow(List<Product> products)
        {
            InitializeComponent();

            localProducts = products;
            LoadMaxCost();
        }

        private void LoadMaxCost()
        {
            MaxCostTb.Text = localProducts.Max(c => c.MinCost).ToString();
        }

        private void MaxCostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^[0-9]]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MaxCostTb.Text))
            {
                foreach (var item in localProducts)
                {
                    item.MinCost = decimal.Parse(MaxCostTb.Text);
                }

                MainWindow.ent.SaveChanges();
                this.Close();
            }
            else
                MessageBox.Show("Данные введены не верно!");
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
