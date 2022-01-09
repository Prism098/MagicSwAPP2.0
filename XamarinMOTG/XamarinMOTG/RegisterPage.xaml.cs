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

// HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
  // personHtmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
    //  personHtmlSource.Html = @"<html><body><div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px;'>
      // <iframe src='https://www.youtube.com/watch?v=dQw4w9WgXcQ' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>
        //  </div></body></html>";
          //  var browser = new WebView();
            // browser.Source = personHtmlSource;
            // Content = browser;
        }

        private async void OpenSurprise(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SurprisePage() { });
        }

        private async void register(object sender, EventArgs e)
        {
            if (passwordEntry.Text != passwordConfirmEntry.Text)
            {
                await DisplayAlert("Passwords Do Not Match", "Passwords do not match. Please try again!", "Okay");
            } 
            else
            {
                // Make connection to data
                SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
                // Create table on login page view (AKA app start)???
                var tempUser = new User();
                tempUser.Id = 0;
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
                    Application.Current.MainPage.Navigation.PopAsync();

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