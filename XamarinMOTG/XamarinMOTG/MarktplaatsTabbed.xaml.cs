using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMOTG
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarktplaatsTabbed : ContentPage
    {

        ObservableCollection<Card> cards = new ObservableCollection<Card>();
        public ObservableCollection<Card> Employees { get { return cards; } }

        public MarktplaatsTabbed()
        {
            InitializeComponent();

            // Both of these will work!
            //this.FindByName<ListView>("Stuff").ItemsSource = cards;
            CardList.ItemsSource = cards;

            Console.WriteLine(CardList.ItemsSource.ToString());

            // ObservableCollection allows items to be added after ItemsSource
            // is set and the UI will react to changes
            cards.Add(new Card { Name = "Brainstorm" });
            cards.Add(new Card { Name = "Deathrite Shaman" });
            cards.Add(new Card { Name = "Lightning Bolt" });
            cards.Add(new Card { Name = "Veil of Summer" });
            cards.Add(new Card { Name = "Sol Ring" });
            cards.Add(new Card { Name = "Indybrick" });

        }

        private void UploadButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UploadItemPage());
        }

        private void MyItemsButton_Clicked(object sender, EventArgs e)
        {

        }

        private void OnCardTapped(Card card, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LoginPage()); 
            Console.WriteLine(card.Name);
        }
    }
}