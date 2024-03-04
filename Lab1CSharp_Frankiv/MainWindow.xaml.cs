using System.Windows;
using Lab1CSharp_Frankiv.ViewModels;

namespace Lab1CSharp_Frankiv
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel();
        }
    }
}
