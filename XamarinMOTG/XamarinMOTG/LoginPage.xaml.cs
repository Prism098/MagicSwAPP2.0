using SQLite;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Game;

        public LoginPage()
        {
            InitializeComponent();

            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

            ToggleAccelerometer();

        }

        // TODO: Reusable - Loop through all Entries and clear them all
        private void ClearFields()
        {
            emailEntry.Text = "";
            passwordEntry.Text = "";
        }

        async void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            Console.WriteLine("Shake detected - clearing fields");
            ClearFields();
            await DisplayAlert("I see you baby, shaking that ass!", "Text has been cleared", "Okay"); // youtube.com/watch?v=DDjoouqRnhk (just in case)
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.Stop();
                    Console.WriteLine("Accelerometer disabled");
                }
                else
                {
                    Accelerometer.Start(speed);
                    Console.WriteLine("Accelerometer enabled");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Console.WriteLine("Shake Not Supported - Shaking would clear fields. However this phone does not have accelerometer support");
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }


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