using System;
using System.Collections.Generic;
using System.Text;
using XamarinMOTG.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace XamarinMOTG.Data
{
    class API
    {
        public async static Task<IList<Drink>> GetCockTailsByrandom()
        {
            IList<Drink> cocktail;

            var link = Cocktail.GeneratedUrlByRandom();

            using (HttpClient cl = new HttpClient())
            {
                var response = await cl.GetAsync(link);
                var json = await response.Content.ReadAsStringAsync();
                var cocktailResponse = JsonConvert.DeserializeObject<ListDRinks>(json);

                cocktail = (List<Drink>)cocktailResponse.drinks;
            }

            return cocktail;
        }
    }
}