using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using TasteCrafters.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;

namespace TasteCrafters.Services
{
    public class SearchService
    {
        private const string _apiKey = "AIzaSyAO4VBmtdgauNugD42mbI70mwiegXc4kI8";
        private const string _searchEngineId = "52fcf9167a9e24a7a";
        
        public static async Task<List<SearchResultModel>> SearchRecipes(string searchString)
        {
            List<SearchResultModel> searchResults = new List<SearchResultModel>();

            string query = $"Recipes with these ingredients, {searchString}";

            string baseUrl = "https://www.googleapis.com/customsearch/v1";
            string parameters = $"key={_apiKey}&cx={_searchEngineId}&q={query}&num=10";

            string url = $"{baseUrl}?{parameters}";
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);
                    JArray items = (JArray)json["items"];
                    
                    
                    searchResults.Clear();

                    foreach (JToken item in items)
                    {
                        SearchResultModel recipe = new SearchResultModel
                        {
                            Title = item["title"].ToString(),
                            Link = item["link"].ToString(),
                            ImageUrl = item["pagemap"]?["cse_image"]?[0]?["src"].ToString()
                        };
                        searchResults.Add(recipe);
                    }
                    return searchResults;
                }
                else
                {
                    Console.WriteLine($"Failed to get response. Status Code: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}