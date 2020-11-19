using System;
using StrongPasswordGenerator.Core;
using Xamarin.Forms;

namespace StrongPasswordGenerator.Mobile
{
    public partial class MainPage : ContentPage
    {
        public int Len { get; set; }
        public bool IncludeSpecialChars { get; set; }
        public bool OnlyUpperCase { get; set; }
        public string GeneratedPassword { get; private set; }
        public bool IsPasswordGenerated => string.IsNullOrEmpty(GeneratedPassword);

        public MainPage()
        {
            InitializeComponent();

            Len = 8;
            IncludeSpecialChars = true;
            OnlyUpperCase = false;
            GeneratedPassword = Password.Generate(Len, IncludeSpecialChars, OnlyUpperCase);

            BindingContext = this;
        }

        private void GenerateLocalPassword(object sender, EventArgs e)
        {
            GeneratedPassword = Password.Generate(Len);
            BindingContext = this;
        }

        private async void CopyToClipBoard(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}
