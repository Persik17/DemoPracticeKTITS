using ParfumeryProj.Model;
using ParfumeryProj.Pages.DataPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace ParfumeryProj.Pages.LoginPages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private string symbols = "1234567890йцукенгшщзхъэждлорпавыфячсмитьбю";
        private string checkCapcha;
        private Random rnd = new Random();

        public AuthPage()
        {
            InitializeComponent();
            GenerateCapcha();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckValidations())
                {
                    User user = MainWindow.ent.User.ToList().Find(x => x.Login == LoginTb.Text && x.Password == PasswordTb.Password && CapchaTb.Text == checkCapcha);

                    if (user != null)
                        NavigationService.Navigate(new ProductPage(user));
                    else
                    {
                        MessageBox.Show("Данного пользователя не существует!");
                        GenerateCapcha();
                        StartBlock();
                    }
                }
                else
                {
                    MessageBox.Show("Некоторые данные введены неверно!");
                    GenerateCapcha();
                    StartBlock();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!");
                StartBlock();
            }
        }

        //Генерация капчи
        private void GenerateCapcha()
        {
            checkCapcha = string.Empty;
            CapchaSp.Children.Clear();

            for (int i = 0; i < 4; i++)
            {
                TextBlock block = new TextBlock()
                {
                    Text = symbols[rnd.Next(0, 42)].ToString(),
                    Margin = new Thickness(0, rnd.Next(10, 18), 0, rnd.Next(10, 18)),
                    Height = rnd.Next(25,45),
                    Width = rnd.Next(10,20),
                    TextDecorations = TextDecorations.Strikethrough,
                    FontSize = 15
                };

                checkCapcha += block.Text;

                CapchaSp.Children.Add(block);
            }
        }

        //Проверка полей
        private bool CheckValidations()
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
                return false;

            if (string.IsNullOrEmpty(PasswordTb.Password))
                return false;

            if (string.IsNullOrEmpty(CapchaTb.Text) || CapchaTb.Text != checkCapcha)
                return false;

            return true;
        }

        private void ReviewBtn_Click(object sender, RoutedEventArgs e)
        {
            User timeUser = new User();

            NavigationService.Navigate(new ProductPage(timeUser));
        }

        private async Task StartBlock()
        {
            PasswordTb.IsEnabled = false;
            LoginTb.IsEnabled = false;
            CapchaTb.IsEnabled = false;
            LogInBtn.IsEnabled = false;
            ReviewBtn.IsEnabled = false;

            await Task.Run(() => Thread.Sleep(10000));

            PasswordTb.IsEnabled = true;
            LoginTb.IsEnabled = true;
            CapchaTb.IsEnabled = true;
            LogInBtn.IsEnabled = true;
            ReviewBtn.IsEnabled = true;
        }
    }
}
