using ParfumeryProj.Model;
using ParfumeryProj.Pages.DataPages;
using ParfumeryProj.Pages.LoginPages;
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

namespace ParfumeryProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PerfumeryEntities ent = new PerfumeryEntities();
        public MainWindow()
        {
            InitializeComponent();

            NavFrame.Navigate(new AuthPage());
        }
    }
}
