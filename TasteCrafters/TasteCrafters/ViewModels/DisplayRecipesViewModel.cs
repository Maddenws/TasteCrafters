using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Windows.Input;
using TasteCrafters.Models;
using TasteCrafters.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TasteCrafters.ViewModels
{
    public class DisplayRecipesViewModel : BindableObject, IQueryAttributable
    {
        private string _passedRecipeQuery;
        public string PassedRecipeQuery
        {
            get { return _passedRecipeQuery; }
            set
            {
                if (_passedRecipeQuery != value)
                {
                    _passedRecipeQuery = value;
                    OnPropertyChanged();
                    LoadRecipes();
                }
            }
        }

        public ObservableCollection<SearchResultModel> Recipes { get; set; } = new ObservableCollection<SearchResultModel>();
        public ICommand OpenLinkCommand { get; }
        public DisplayRecipesViewModel()
        {
            OpenLinkCommand = new Command<string>((url) =>
            {
                Launcher.OpenAsync(new Uri(url));
            });
        }


        string passedRecipeQuery;
        //using to pass in the query string from the mainViewModel
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            //get the Id here.  
            PassedRecipeQuery = HttpUtility.UrlDecode(query["query"]);

        }

        private async void LoadRecipes()
        {
            if (!string.IsNullOrWhiteSpace(PassedRecipeQuery))
            {
                var results = await SearchService.SearchRecipes(PassedRecipeQuery);
                if (results != null)
                {
                    Recipes.Clear();
                    foreach (var result in results)
                    {
                        Recipes.Add(result);
                    }
                }
            }
        }
    }
}
