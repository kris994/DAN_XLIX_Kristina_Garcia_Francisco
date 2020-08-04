using DAN_XLIX_Kristina_Garcia_Francisco.ViewModel;
using System.Windows;

namespace DAN_XLIX_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Window
    {
        /// <summary>
        /// Shows all users in the system
        /// </summary>
        public AllUsers()
        {
            InitializeComponent();
            this.DataContext = new AllUsersViewModel(this);
        }
    }
}
