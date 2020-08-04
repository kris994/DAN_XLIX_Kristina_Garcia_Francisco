using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using DAN_XLIX_Kristina_Garcia_Francisco.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this);
        }

        /// <summary>
        /// Window constructor for editing manager
        /// </summary>
        /// <param name="managerEdit">manager that is bing edited</param>
        public AddManager(vwManager managerEdit)
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this, managerEdit);
        }

        /// <summary>
        /// User can only imput numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
