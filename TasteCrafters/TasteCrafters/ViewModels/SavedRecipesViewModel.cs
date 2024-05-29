using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasteCrafters.DataAccess;
using TasteCrafters.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TasteCrafters.ViewModels
{
    public class SavedRecipesViewModel : BindableObject
    {
        private IDataAccess _dataAccess;

        public ICommand OpenLinkCommand { get; }

        public ICommand DeleteRecipeCommand { get; }

        public ICommand NavigateToSavedRecipesPageCommand { get; }
        public SavedRecipesViewModel()
        {
            _dataAccess = DependencyService.Get<IDataAccess>();
            SavedRecipeList = new ObservableCollection<SavedRecipeModel>();
            GetSavedRecipes();

            OpenLinkCommand = new Command<string>((url) =>
            {
                Launcher.OpenAsync(new Uri(url));
            });

            DeleteRecipeCommand = new Command<SavedRecipeModel>(ExecuteDeleteRecipeCommand);

            NavigateToSavedRecipesPageCommand = new Command(async () => await NavigateToSavedRecipesPage());
        }

        private ObservableCollection<SavedRecipeModel> _savedRecipeList;
        public ObservableCollection<SavedRecipeModel> SavedRecipeList
        {
            get { return _savedRecipeList; }
            set
            {
                _savedRecipeList = value;
                OnPropertyChanged(nameof(SavedRecipeList));
            }
        }



        public void GetSavedRecipes()
        {
            _dataAccess.GetAllRecipes().ForEach(recipe => 
            {
                SavedRecipeList.Add(recipe);

            });
        }

        private void ExecuteDeleteRecipeCommand(SavedRecipeModel recipe)
        {
            if (recipe != null)
            {
                _dataAccess.DeleteRecipe(recipe.Id);
                SavedRecipeList.Remove(recipe);
            }
        }

        public void RefreshPage(SavedRecipeModel r)
        {
            SavedRecipeList.Clear();
            GetSavedRecipes();
        }

        private async Task NavigateToSavedRecipesPage()
        {
            // This method will contain the navigation logic
            var navigation = Application.Current.MainPage.Navigation;
            var navigationStack = navigation.NavigationStack.ToList();

            // Remove the current instance of SavedRecipesPage
            foreach (var page in navigationStack)
            {
                if (page is SavedRecipesPage)
                {
                    navigation.RemovePage(page);
                }
            }

            // Push a new instance of SavedRecipesPage
            await navigation.PushAsync(new SavedRecipesPage());
        }
    }
}
