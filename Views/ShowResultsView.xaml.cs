using Lab02.ViewModels;
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

namespace Lab02.Views
{
    /// <summary>
    /// Interaction logic for ShowResultsView.xaml
    /// </summary>
    public partial class ShowResultsView : UserControl
    {
        private ShowResultsViewModel _viewModel;

        public ShowResultsView(Action a)
        {
            InitializeComponent();
            DataContext = _viewModel = new ShowResultsViewModel(a);
        }
    }
}
