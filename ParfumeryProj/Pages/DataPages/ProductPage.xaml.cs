using ParfumeryProj.Model;
using ParfumeryProj.Pages.AddEditPages;
using ParfumeryProj.Windows.AddEditWindows;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private static List<Product> products = new List<Product>();

        private static User localUser;
        private static int take = 10;
        private static int skip = 0;

        public ProductPage(User user)
        {
            InitializeComponent();

            localUser = user;

            ProductList.ItemsSource = MainWindow.ent.Product.Where(c => !c.IsDeleted).ToList().Take(10);
            products = MainWindow.ent.Product.Where(c => !c.IsDeleted).ToList();

            FillComboBox();
            UserSettings();
        }

        private void UserSettings()
        {
            if (localUser.RoleID != 0 && localUser.RoleID != 1)
                ToOrdersBtn.Visibility = Visibility.Visible;

            if (localUser.RoleID == 2)
                AddProductBtn.Visibility = Visibility.Visible;
        }

        private void FillComboBox()
        {
            FiltrCb.Items.Clear();
            FiltrCb.Items.Add("Все типы");
            foreach (var item in MainWindow.ent.ProductType)
            {
                FiltrCb.Items.Add(item.Name);
            }
        }

        private void Filter()
        {
            products = MainWindow.ent.Product.Where(c => !c.IsDeleted).ToList();

            List<Product> titleList = new List<Product>();
            List<Product> typeList = new List<Product>();
            List<Product> prodList = new List<Product>();

            if (!string.IsNullOrEmpty(SearchTb.Text) && SearchTb.Text != "Введите для поиска")
                titleList = products.Where(c => c.Title.StartsWith(SearchTb.Text) && !c.IsDeleted).ToList();

            if (FiltrCb.SelectedIndex == 0)
                typeList = MainWindow.ent.Product.Where(c => !c.IsDeleted).ToList();
            else if (FiltrCb.SelectedIndex != -1)
                typeList = products.Where(c => c.ProductTypeID == FiltrCb.SelectedIndex && !c.IsDeleted).ToList();

            if (typeList.Count != 0 && typeList.Count != 0)
                products = prodList.Concat(titleList).Concat(typeList).Distinct().ToList();


            if (SortCb.SelectedIndex != -1)
            {
                if (SortCb.SelectedIndex == 0)
                    products = products.OrderBy(c => c.Title).ToList();
                if (SortCb.SelectedIndex == 1)
                    products = products.OrderByDescending(c => c.Title).ToList();
                if (SortCb.SelectedIndex == 2)
                    products = products.OrderBy(c => c.MinCost).ToList();
                if (SortCb.SelectedIndex == 3)
                    products = products.OrderByDescending(c => c.MinCost).ToList();
            }

            ProductList.ItemsSource = products;
        }

        private void SearchTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTb.Text == "Введите для поиска")
                SearchTb.Text = string.Empty;
        }

        private void SearchTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTb.Text))
                SearchTb.Text = "Введите для поиска";
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2 && localUser.ID != 0 && localUser.RoleID != 1)
                NavigationService.Navigate(new AddEditProductPage((sender as StackPanel).DataContext as Product, localUser, true));
        }

        private void ChangeMinCostBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Product> costProd = new List<Product>();

            foreach (var item in ProductList.SelectedItems)
            {
                costProd.Add(item as Product);
            }

            EditMinCostWindow editMinCostWindow = new EditMinCostWindow(costProd);
            editMinCostWindow.ShowDialog();
        }

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductList.SelectedItems.Count > 1 && localUser.RoleID != 0 && localUser.RoleID != 1)
                ChangeMinCostBtn.Visibility = Visibility.Visible;
            else
                ChangeMinCostBtn.Visibility = Visibility.Hidden;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FiltrCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SearchTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Filter();
        }

        private void ToOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(localUser));
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(new Product(), localUser, false));
        }
    }
}
