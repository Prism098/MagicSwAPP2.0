using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;


namespace XamarinMOTG
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            // Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            MainPage = new NavigationPage(new LoginPage());
        
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        protected void OnAppearing()
        {


        }
    }
}
