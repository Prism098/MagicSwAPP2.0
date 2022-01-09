using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectieTabbed : ContentPage
    {
        HttpClient client;

        public CollectieTabbed()
        {
            InitializeComponent();

            this.BindingContext = new[] { "a", "b", "c" };
        }

        public class Card
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("set")]
            public string Set { get; set; }

            [JsonProperty("image_uris")]
            public CardImageUris ImageUris { get; set; }

            // public bool Active { get; set; }
            // public DateTime CreatedDate { get; set; }
            // public IList<string> Roles { get; set; }
        }

        public class CardImageUris
        {
            [JsonProperty("small")]
            public string Small { get; set; }
        }

        public class CardSet
        {
            [JsonProperty("data")]
            public IList<Card> Data { get; set; }
        }

      

        protected override async void OnAppearing()
        {

            client = new HttpClient();

            // Make the URI from static string (hard coded for now)
            Uri uri = new Uri("https://api.scryfall.com/cards/search?q=a");

            // Actually start MAKING the HTTP request
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("I got the HTTPS request with a 200(ish) response");

                string content = await response.Content.ReadAsStringAsync();

                // Testing to see if EXTRA JSON properties will break this JSON serialiser package
                CardSet cardSet = JsonConvert.DeserializeObject<CardSet>(content);

                this.BindingContext = cardSet.Data;

                Console.WriteLine(cardSet.Data[0].Name);
            }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        async void OnCellClicked(object sender, EventArgs args)
        {
            var imageSender = (Xamarin.Forms.Image)sender;
            
            if (imageSender.GestureRecognizers.Count > 0)
            {
                var gesture = (TapGestureRecognizer)imageSender.GestureRecognizers[0];
                var data = gesture.CommandParameter;
                
                Debug.WriteLine("clicked " + data);
                await DisplayAlert("Clicked", data + "'s delete button was clicked", "K");
            } else
            {
                await DisplayAlert("Error", "Something unusual was clicked...", "K");
            }

            // HOW DO ONE GET THE BOUNDARY THINGIES? Yeh back 2 app x3
            // var t = b.CommandParameter;

            // await ((ContentPage)((ListView)((ViewCell)((StackLayout)b.Parent).Parent).Parent).Parent).DisplayAlert("Clicked", t + " button was clicked", "OK");
        }

    }
}