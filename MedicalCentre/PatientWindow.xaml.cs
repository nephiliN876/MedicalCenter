﻿using System;
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
    /// Логика взаимодействия для PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Patient_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow2 patientWindow2 = new PatientWindow2();
            patientWindow2.Show();
            Hide();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VisitDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VisitDataGrid.ItemsSource = DBMedical.entObj.PatientWindow.ToList();

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DBMedical.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                VisitDataGrid.ItemsSource = DBMedical.entObj.PatientWindow2.ToList();
            }
        }
    }
}
