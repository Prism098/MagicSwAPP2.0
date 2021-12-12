using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMOTG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            // Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());
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
    }
}
