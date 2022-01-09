using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMOTG.Model;

namespace XamarinMOTG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuestionEntry.Text))
            {
                QuestionEntry.Text = "Enter a Question!";
            }
            else
            {
                Question question = new Question();
                question.QuestionBody = QuestionEntry.Text;

                SQLiteConnection Sqliteconnection = new SQLiteConnection(App.DatabaseLocation);
                Sqliteconnection.CreateTable<Question>();
                int insertRows = Sqliteconnection.Insert(question);
                Sqliteconnection.Close();
                Console.WriteLine(insertRows + " testing if the function works");

                //base.OnAppearing();
                SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteConnection.CreateTable<Question>();
                //TableQueryObject
                List<Question> QuestionList = sQLiteConnection.Table<Question>().ToList();

                sQLiteConnection.Close();

            }
        }
    }
}