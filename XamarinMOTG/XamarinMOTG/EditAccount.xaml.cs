using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAccount : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Game;

        public EditAccount()
        {
            InitializeComponent();

            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

            ToggleAccelerometer();
        }

        private void SaveEdits(object sender, EventArgs e)
        {

        }

        private void RevertEdits(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
        private void ClearEdits(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DeleteAccount(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            emailEntry.Text = "";
            usernameEntry.Text = "";
            passwordEntry.Text = "";
            passwordConfirmEntry.Text = "";
        }

        async void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            Console.WriteLine("Shake detected - clearing fields");
            ClearFields();
            await DisplayAlert("Shake detected", "Text has been cleared", "Okay");
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
    }
}