using MyVault.Mobile.Models;
using Xamarin.Forms;

namespace MyVault.Mobile
{
    public partial class MainPage : ContentPage
    {
        public GeneratePasswordViewModel Model { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Model = new GeneratePasswordViewModel();
            BindingContext = Model;
        }

        void HandleFormSubmit(object sender, System.EventArgs e)
        {
            Model.Refresh();
            BindingContext = Model;
        }
    }
}
