using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

        }

        private async void OpenSurprise(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SurprisePage() { });
        }

        private async void register(object sender, EventArgs e)
        {
            if (passwordEntry.Text != passwordConfirmEntry.Text)
            {
                await DisplayAlert("Passwords Don't Match", "Passwords do not match. Please try again!", "Okay");
            } 
            else
            {
                // Make connection to data
                SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
                
                var tempUser = new User();
                tempUser.Username = usernameEntry.Text;
                tempUser.Name = nameEntry.Text;
                tempUser.Email = emailEntry.Text;
                tempUser.Password = passwordEntry.Text;

                try
                {
                    connection.Insert(tempUser);
                    // Tell user
                    await DisplayAlert("Success", "Account was created", "Okay");
                    
                    // Go back a page (assumes from login)
                    await Application.Current.MainPage.Navigation.PopAsync();

                }
                catch (SQLite.SQLiteException)
                {
                    await DisplayAlert("Error", "Email likely already in use. Please use another.", "Okay");
                }

                connection.Close();
            }
        }

    }
}