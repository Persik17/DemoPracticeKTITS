using Microsoft.Win32;
using ParfumeryProj.Model;
using ParfumeryProj.Pages.DataPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParfumeryProj.Pages.AddEditPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        private static Product localProduct;
        private static User localUser;
        private static string localUrl;
        private static bool localIsEdit;

        public AddEditProductPage(Product product, User user, bool isEdit)
        {
            InitializeComponent();

            ProdTypeCb.ItemsSource = MainWindow.ent.ProductType.ToList();

            localProduct = product;
            localUrl = localProduct.Photo;
            localUser = user;
            localIsEdit = isEdit;

            DataContext = localProduct;

            if (string.IsNullOrEmpty(localUrl))
                ChangeImageBtn.Content = "Добавить фото";
            else
                ChangeImageBtn.Content = "Изменить фото";

            UserSettings();
        }

        private void UserSettings()
        {
            if (localUser.RoleID == 3)
            {
                DeleteBtn.Visibility = Visibility.Hidden;
                SaveBtn.Visibility = Visibility.Hidden;
                ChangeImageBtn.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "*.png|*.jpg",
            };

            if (dialog.ShowDialog().GetValueOrDefault())
            {
                ProdImage.Source = new BitmapImage(new Uri(dialog.FileName));
                localUrl = new BitmapImage(new Uri(dialog.FileName)).ToString();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckValidations())
                {
                    localProduct.Photo = localUrl;

                    if (!localIsEdit)
                        MainWindow.ent.Product.Add(localProduct);

                    MainWindow.ent.SaveChanges();
                    NavigationService.Navigate(new ProductPage(localUser));
                }
                else
                    MessageBox.Show("Не все поля заполнены!");
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(localUser));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы действительно хотите удалить этот продукт?","Внимание!",MessageBoxButton.YesNo);
            int countSales = MainWindow.ent.Basket.Where(c => c.ProductID == localProduct.ID).Count();
            int countHistory = MainWindow.ent.HistoryChangeProductPrice.Where(c => c.ProductID == localProduct.ID).Count();

            if (countSales == 0 && countHistory == 0)
            {
                localProduct.IsDeleted = true;
                MainWindow.ent.SaveChanges();

                NavigationService.Navigate(new ProductPage(localUser));
            }
            else
                MessageBox.Show("Товар не может быть удален, т.к. он числится в других таблицах!");
        }

        private bool CheckValidations()
        {
            try
            {
                if (string.IsNullOrEmpty(TitleTb.Text) || TitleTb.Text.Length > 60)
                    return false;

                if (string.IsNullOrEmpty(ArticleTb.Text) || ArticleTb.Text.Length > 8)
                    return false;

                if (string.IsNullOrEmpty(MinCostTb.Text))
                    return false;

                decimal.Parse(MinCostTb.Text.Replace('.',','));

                if (ProdTypeCb.SelectedIndex == -1)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ArticleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Я0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MinCostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
