using ParfumeryProj.Model;
using ParfumeryProj.Pages.DataPages;
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

namespace ParfumeryProj.Pages.AddEditPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {
        private static Order localOrder;
        private static User localUser;
        private static bool localIsEdit;

        public AddEditOrderPage(Order order, User user, bool isEdit)
        {
            InitializeComponent();

            localOrder = order;
            localUser = user;
            localIsEdit = isEdit;

            DataContext = localOrder;

            BasketGrid.ItemsSource = MainWindow.ent.Basket.Where(c => c.OrderID == localOrder.ID).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidation())
            {

            }
            else
                MessageBox.Show("Заказ пустой или статус не установлен!");
        }

        private bool CheckValidation()
        {
            if (TypeOrderCb.SelectedIndex == -1)
                return false;

            if (BasketGrid.Items.Count == 0)
                return false;

            return true;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(localUser));
        }

        private void AddProdBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProdBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
