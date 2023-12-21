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
    /// Логика взаимодействия для PatientWindow2.xaml
    /// </summary>
    public partial class PatientWindow2 : Window
    {
        public PatientWindow2()
        {
            InitializeComponent();
        }

        private void Appointment_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow patientWindow = new PatientWindow();
            patientWindow.Show();
            Hide();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ZapisWindow zapisWindow = new ZapisWindow();
            zapisWindow.Show();
            this.Hide();

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var recipeForRemoving = PatientDataGrid.SelectedItems.Cast<PatientWindow2>().ToList();

            try
            {
                var result = MessageBox.Show("Вы уверены?",
                    "Уведомление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DBMedical.entObj.PatientWindow2.RemoveRange(recipeForRemoving);
                    DBMedical.entObj.SaveChanges();

                    MessageBox.Show("Данные удалены.",
                         "Уведомление",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
                    PatientDataGrid.ItemsSource = DBMedical.entObj.PatientWindow2.ToList();
                }
                else
                {
                    PatientDataGrid.ItemsSource = DBMedical.entObj.PatientWindow2.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                    "Критический сбой работы приложения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    


        private void PatientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DBMedical.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                PatientDataGrid.ItemsSource = DBMedical.entObj.PatientWindow2.ToList();
            }
        }
    }
}
