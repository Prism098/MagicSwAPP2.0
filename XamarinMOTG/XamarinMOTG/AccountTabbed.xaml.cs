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
    public partial class AccountTabbed : ContentPage
    {
        public AccountTabbed()
        {
            InitializeComponent();
        }

        private async void EditAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditAccount() { });
        }

        private async void DeleteAccount(object sender, EventArgs e)
        {
            await DisplayAlert("Confirm Deletion", "Please confirm deletion!", "Confirm", "Cancel");
        }
    }
}