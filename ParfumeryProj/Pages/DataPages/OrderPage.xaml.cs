using ParfumeryProj.Model;
using ParfumeryProj.Pages.AddEditPages;
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

namespace ParfumeryProj.Pages.DataPages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private static User localUser;
        public OrderPage(User user)
        {
            InitializeComponent();

            localUser = user;

            UserSettings();
        }

        private void FillComboBox()
        {
            ManagerCb.Items.Clear();
            ManagerCb.Items.Add("Все менеджеры");
            foreach (var item in MainWindow.ent.User.Where(c => c.RoleID == 3).ToList())
            {
                ManagerCb.Items.Add(item.Surname);
            }
        }

        private void UserSettings()
        {
            if (localUser.RoleID == 3)
                OrderList.ItemsSource = MainWindow.ent.Order.Where(c => !c.IsDeleted && (c.ManagerUserID == localUser.ID || c.ManagerUserID == null)).ToList();
            else if (localUser.RoleID == 2)
            {
                OrderList.ItemsSource = MainWindow.ent.Order.Where(c => !c.IsDeleted).ToList();
                ManagerCb.Visibility = Visibility.Visible;
                FillComboBox();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(localUser));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ManagerCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditOrderPage(new Order(), localUser, false));
        }

        private void Filter()
        {
            if (ManagerCb.SelectedIndex != -1)
            {
                if (ManagerCb.SelectedIndex == 0)
                {
                    OrderList.ItemsSource = MainWindow.ent.Order.Where(c => !c.IsDeleted).ToList();
                }
                else
                {
                    OrderList.ItemsSource = MainWindow.ent.Order.Where(c => !c.IsDeleted && c.User.Surname == ManagerCb.SelectedItem.ToString()).ToList();
                }
            }
        }
    }
}
