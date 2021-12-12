using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            await DisplayAlert("got you now", "Now you must agree to the following: You should not have clicked this button", "I agree.");
            
        }

        private void UploadToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UploadItemPage());
        }
    }
}