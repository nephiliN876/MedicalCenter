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
using System.Windows.Shapes;

namespace MedicalCentre
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        public AuthWindow()
        {
            InitializeComponent();
            DBMedical.entObj = new MedicalCenterEntities();
        }

        private void Button_Authclick_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow patientWindow = new PatientWindow();
            patientWindow.Show();
            Hide();
            try
            {
                var userObj = DBMedical.entObj.User.FirstOrDefault(x => x.Name == textBoxLogin.Text && x.Password == passBox.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден!",
                               "Уведомление",
                               MessageBoxButton.OK,
                              MessageBoxImage.Information);
                   
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, " + userObj.Name + "!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте,  " + userObj.Name + "!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Такой пользователь не найден!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            break;
                            

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе предложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);


            }
        }
    }

}
