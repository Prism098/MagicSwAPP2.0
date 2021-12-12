using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                Navigation.PushAsync(new HomePage() { BarBackgroundColor = Color.Green });
            }

        }

    }

}