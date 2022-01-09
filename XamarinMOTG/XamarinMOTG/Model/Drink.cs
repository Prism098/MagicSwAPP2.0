using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMOTG.Model
{
    public class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public object strDrinkAlternate { get; set; }
        public string AllIngrediants
        {
            get
            {
                return strIngredient1 + ", " + strIngredient2 + ", " + strIngredient3 + ", " + strIngredient4 + ", " + strIngredient4 + ", " +
                        strIngredient5 + ", " + strIngredient6 + ", " + strIngredient7 + ", " + strIngredient8 + ", " + strIngredient9 + ", " + strIngredient10 + ", " + strIngredient11 + ", " +
                        strIngredient12 + ", " + strIngredient13 + ", " + strIngredient14 + ", " + strIngredient15;
            }
        }
        public string strTags { get; set; }
        public object strVideo { get; set; }
        public string strCategory { get; set; }
        public object strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public object strInstructionsES { get; set; }
        public object strInstructionsDE { get; set; }
        public object strInstructionsFR { get; set; }
        public string strDrinkThumb { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public object strIngredient8 { get; set; }
        public object strIngredient9 { get; set; }
        public object strIngredient10 { get; set; }
        public object strIngredient11 { get; set; }
        public object strIngredient12 { get; set; }
        public object strIngredient13 { get; set; }
        public object strIngredient14 { get; set; }
        public object strIngredient15 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public object strMeasure8 { get; set; }
        public object strMeasure9 { get; set; }
        public object strMeasure10 { get; set; }
        public object strMeasure11 { get; set; }
        public object strMeasure12 { get; set; }
        public object strMeasure13 { get; set; }
        public object strMeasure14 { get; set; }
        public object strMeasure15 { get; set; }
        public string strImageSource { get; set; }
        public object strImageAttribution { get; set; }
        public string strCreativeCommonsConfirmed { get; set; }
        public object dateModified { get; set; }
    }
}

