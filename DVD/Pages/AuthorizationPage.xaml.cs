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
using DVD.Connection;

namespace DVD.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Sotrudnik sotrudnik;

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new capch());
        }


        private void tbReg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

        private void tbReg_MouseEnter(object sender, MouseEventArgs e)
        {
            tbReg.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void tbReg_MouseLeave(object sender, MouseEventArgs e)
        {
            int login = Convert.ToInt32(tbReg.Text.Trim());
            string password=TbPassword.Password.Trim();
            sotrudnik=Authorisation.AuthotisationSotr(login, password);
            if (sotrudnik != null)
            {
                MessageBox.Show("Ура в меня вошли");
            }
            else
            {
                MessageBox.Show("логин или пароль неверный", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
