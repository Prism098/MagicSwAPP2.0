using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Connections;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            bool isUsernameEmpty = string.IsNullOrEmpty(usernameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isUsernameEmpty || isPasswordEmpty)
            {
                usernameLabel.Text = "Enter login.";
            }
            else
            {
                var users = LoginService.GetUser(usernameEntry.Text, passwordEntry.Text);
                Navigation.PushAsync(new HomePage() { BarBackgroundColor = Color.FromHex("#2C394B") });
            }

        }

    }

}