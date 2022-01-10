using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectieTabbed : ContentPage
    {
        HttpClient client;

        public CollectieTabbed()
        {
            InitializeComponent();
            // Init empty string array (cards before loaded)
            this.BindingContext = new string[] { };
        }

        public class Card
        {
            // The name that the API gives (could break if the API changes - extra params are ignored, thankfully)
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("set")]
            public string Set { get; set; }

            [JsonProperty("scryfall_uri")]
            public string URI { get; set; }

            [JsonProperty("oracle_text")]
            public string Description { get; set; }

            [JsonProperty("image_uris")]
            public CardImageUris ImageUris { get; set; }

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

            // If a 200-like response
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("I got the HTTPS request with a 200(ish) response");

                string content = await response.Content.ReadAsStringAsync();

                // Testing to see if EXTRA JSON properties will break this JSON serialiser package
                CardSet cardSet = JsonConvert.DeserializeObject<CardSet>(content);

                this.BindingContext = cardSet.Data;
            }
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row

            var tappedCard = (Card)e.Item;

            // TODO: Open a profile page for each card (ACTUALLY, open the website with a browser)
            await Browser.OpenAsync(tappedCard.URI, BrowserLaunchMode.SystemPreferred);
        }

        async void OnCellShareClicked(object sender, EventArgs args)
        {
            var imageSender = (Xamarin.Forms.Image)sender;
            
            if (imageSender.GestureRecognizers.Count > 0)
            {
                var gesture = (TapGestureRecognizer)imageSender.GestureRecognizers[0];
                var data = gesture.CommandParameter;

                // Could break?...
                var tappedCard = (Card)data;
                
                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = "Shared MOTG Card",
                    Text = "I found this MOTG card called " + tappedCard.Name + ". Learn more at: " + tappedCard.URI
                });
            } else
            {
                await DisplayAlert("Error", "Something unusual was clicked...", "K");
            }
        }

    }
}