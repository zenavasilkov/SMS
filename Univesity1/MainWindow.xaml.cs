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
using UniversityApp.WPF.Controls;
using UniversityApp.WPF.Views;

namespace UniversityApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContentControl.Content = new StudentsView();

            var dialog = new StudentDialog();
            dialog.ShowDialog();

        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        { 
            MainContentControl.Content = new StudentsView();
        }

        private void GroupsButton_Click(object sender, RoutedEventArgs args)
        {
            MainContentControl.Content = new GroupsView();
        }

        private void RecordsButton_Click(Object sender, RoutedEventArgs args)
        {
            MainContentControl.Content = new RecordsView();
        }

        private void SubjectsButton_Click(object sender, RoutedEventArgs args)
        {
            MainContentControl.Content = new SubjectsView();
        }

        private void ExitButton_Click(Object sender, RoutedEventArgs e)
        { 
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentControl.Content is StudentsView studentsView)
            {
                var vm = studentsView.ViewModel;
                var studentToRemove = vm.SelectedStudent;

                if (studentToRemove != null) vm.Students.Remove(studentToRemove); 
            }
        }

    }
}
