using SQLite;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{ 
        //    base.OnAppearing();
        //}


        private void printTempUser(object sender, EventArgs e)
        {
            // Make connection to data
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            // Create table
            connection.CreateTable<User>();
            var users = connection.Table<User>().ToList();

            foreach (var user in users)
            {
                Console.WriteLine("User Id: " + user.Id + " has email '" + user.Email + "' and has password '" + user.Password + "'");
            }
            Console.WriteLine("There are " + users.Count + " registered users");

            connection.Close();
        }


        private async void GoToRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage() { });
        }

        private async void Login(object sender, EventArgs e)
        {

            bool isUsernameEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isUsernameEmpty || isPasswordEmpty)
            {
                await DisplayAlert("Invalid Content", "Please enter a valid username, email and password", "Okay");
            }
            else
            {
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

                try
                {
                    // Insecure technically, would need some sort of sanitisation to make secure
                    string query = $"SELECT * FROM users WHERE email = '" + emailEntry.Text  + "';";

                    var results = conn.Query<User>(query);

                    if (results.Count < 1)
                    {
                        await DisplayAlert("Error", "Email is not registered.", "Okay");
                    }
                    else
                    {
                        if (passwordEntry.Text == results[0].Password)
                        {
                            // Push navigation first so that there's instant user feedback
                            await Navigation.PushAsync(new HomePage() { BarBackgroundColor = Color.FromHex("#2C394B") });

                            // User logged in (todo, save information)
                            await DisplayAlert("Welcome", "Welcome " + results[0].Name, "Okay");
                        } 
                        else
                        {
                            await DisplayAlert("Error", "Password is wrong", "Okay");
                        }
                    }

                    conn.Close();
                }
                catch (SQLite.SQLiteException)
                {
                    await DisplayAlert("Error", "Error logging in.", "Okay");
                }
            }

        }
    }

}