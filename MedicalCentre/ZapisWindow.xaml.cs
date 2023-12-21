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
    /// Логика взаимодействия для ZapisWindow.xaml
    /// </summary>
    public partial class ZapisWindow : Window
    {
        public ZapisWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            try
            {
               PatientWindow2  productObj = new PatientWindow2()
                {
                   Name = TextBoxFirstName.Text,
                    Imya = TextBoxFirstName.Text,
                    Surname = TextBoxLastName.Text,
                    Adress = TextBoxAddress.Text,
                    Pol = MaleCheckBox.Text,
                    DateBirthDay = Convert.ToDateTime(dpBirthDate.Text),
               };
                DBMedical.entObj.PatientWindow2.Add(productObj);
                DBMedical.entObj.SaveChanges();

                MessageBox.Show("Пациент добавлен!",
                "Уведомление",
                MessageBoxButton.OK,
               MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                    "Критический сбой работы приложения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }



        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            PatientWindow2 patientWindow2 = new PatientWindow2();
            patientWindow2.Show();
            Hide();
        }

        private void MaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void FemaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
