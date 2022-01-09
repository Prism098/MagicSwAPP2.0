using System;
using System.Collections.Generic;
using System.Text;
using XamarinMOTG.Data;
using static Android.Provider.SyncStateContract;

namespace XamarinMOTG.Model
{
    class Cocktail
    {
        public static string GeneratedUrlByName(string Name)
        {
            return string.Format(CocktailConstants.CocktailByname, Name);
        }

        public static string GeneratedUrlByIngrediant(string Ingrediant)
        {
            return string.Format(CocktailConstants.CocktailbyIngrediant, Ingrediant);
        }

        public static string GeneratedUrlByRandom()
        {
            return CocktailConstants.CocktailByRandom;
        }
    }
}
