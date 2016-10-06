using FI_Dev.ViewModels;

namespace FI_Dev.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WordsCounterViewModel();
        }
    }
}
