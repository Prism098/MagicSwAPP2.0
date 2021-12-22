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



        private async void GoToRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage() { });
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            bool isUsernameEmpty = string.IsNullOrEmpty(usernameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isUsernameEmpty || isPasswordEmpty)
            {
                await DisplayAlert("Invalid Content", "Please enter a valid username, email and password", "Okay");
                // usernameLabel.Text = "Enter login.";
            }
            else
            {
                //base.OnAppearing();
                SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteConnection.CreateTable<User>();
                //TableQueryObject
                var users = sQLiteConnection.Table<User>().ToList();
                sQLiteConnection.Close();

                //User user = new User();
                //user.Name = usernameEntry.Text;
                //user.Password = passwordEntry.Text;
                //user.Email = emailEntry.Text;

                //SQLiteConnection Sqliteconnection = new SQLiteConnection(App.DatabaseLocation);
                //Sqliteconnection.CreateTable<User>();
                //int insertRows = Sqliteconnection.Insert(user);
                //Sqliteconnection.Close();
                //Console.WriteLine(insertRows + " testing if the function works");


                await Navigation.PushAsync(new HomePage() { BarBackgroundColor = Color.FromHex("#2C394B") });
            }

        }

    }

}