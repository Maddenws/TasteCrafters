using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Windows.Input;
using TasteCrafters.DataAccess;
using TasteCrafters.Models;
using TasteCrafters.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TasteCrafters.ViewModels
{
    public class DisplayRecipesViewModel : BindableObject, IQueryAttributable
    {
        private string _passedRecipeQuery;

        private IDataAccess _dataAccess;
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
        public ICommand SaveRecipeCommand { get; }
        public DisplayRecipesViewModel()
        {
            OpenLinkCommand = new Command<string>((url) =>
            {
                Launcher.OpenAsync(new Uri(url));
            });

            SaveRecipeCommand = new Command<SearchResultModel>((recipe) =>
            {
                SaveRecipe(recipe);
            });

            _dataAccess = DependencyService.Get<IDataAccess>();
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

        private void SaveRecipe(SearchResultModel recipe)
        {
            var savedRecipe = new SavedRecipeModel
            {
                Title = recipe.Title,
                Link = recipe.Link,
                ImageUrl = recipe.ImageUrl
            };

            
            _dataAccess.AddNewRecipe(savedRecipe);

        }

    }
}
