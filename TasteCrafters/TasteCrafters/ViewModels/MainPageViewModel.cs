using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using TasteCrafters.Models;
using TasteCrafters.Services;
using System.Windows.Input;
using TasteCrafters.Views;

namespace TasteCrafters.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private GetIngredientListType _ingredientService;
        private IngredientStringBuilder _ingredientStringBuilder;
        public ObservableCollection<IngredientGroup> Ingredients { get; set; }
        public ObservableCollection<IngredientModel> SelectedIngredients { get; set; }

        public ICommand SubmitCommand { get; set; }
        public ICommand AddIngredientCommand { get; set; }

        public ICommand ToggleVisibilityLayoutCommand {  get; set; }

        public MainPageViewModel()
        {
             IsLayoutVisible = true;
            _ingredientService = DependencyService.Get<GetIngredientListType>();
            _ingredientService.PopulateCollection();
            _ingredientStringBuilder = DependencyService.Get<IngredientStringBuilder>();
            Ingredients = new ObservableCollection<IngredientGroup>
            {
                new IngredientGroup("Meats", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Meats)),
                new IngredientGroup("Rice", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Rice)),
                new IngredientGroup("Grains", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Grains)),
                new IngredientGroup("Beans", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Beans)),
                new IngredientGroup("Fish", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Fish)),
                new IngredientGroup("Poultry", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Poultry)),
                new IngredientGroup("Produce", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Produce)),
                new IngredientGroup("Fruits", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Fruits)),
                new IngredientGroup("Eggs", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Eggs)),
                new IngredientGroup("Shellfish", _ingredientService.GetTypeOfIngredient(IngredientsOptions.Shellfish))
            };

            SelectedIngredients = new ObservableCollection<IngredientModel>();

            // Subscribe to property changes to handle selections.
            foreach (var group in Ingredients)
            {
                foreach (var ingredient in group)
                {
                    ingredient.PropertyChanged += Ingredient_PropertyChanged;
                }
            }

            SubmitCommand = new Command(ExecuteSubmitCommand);
            AddIngredientCommand = new Command(ExecuteAddIngredientCommand);
            ToggleVisibilityLayoutCommand = new Command(ExecuteToggleVisibilityCommand);
            IsLayoutVisible = false;
        }

        private void Ingredient_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IngredientModel.IsSelected))
            {
                var ingredient = sender as IngredientModel;
                if (ingredient == null) return;

                if (ingredient.IsSelected && !SelectedIngredients.Contains(ingredient))
                {
                    ingredient.IsSelected = true;
                    SelectedIngredients.Add(ingredient);

                }
                else if (!ingredient.IsSelected && SelectedIngredients.Contains(ingredient))
                {
                    ingredient.IsSelected = false;
                    SelectedIngredients.Remove(ingredient);
                }
            }
        }

        private bool _isLayoutVisible;
        public bool IsLayoutVisible
        {
            get { return _isLayoutVisible; }
            set
            {
                _isLayoutVisible = value;
                OnPropertyChanged(nameof(IsLayoutVisible));
            }
        }
        private string _userAddedIngredient;
        public string UserAddIngredient
        {
            get
            { 
                return _userAddedIngredient;
            }
            set 
            {
                _userAddedIngredient = value;
                OnPropertyChanged(nameof(_userAddedIngredient));
            }
        }
        private async void ExecuteSubmitCommand()
        {
            string query = "Recipes that start with ";
            _ingredientStringBuilder.CreateQueryString(SelectedIngredients);
            string queryString = query + _ingredientStringBuilder.GetString();

            queryString = Uri.EscapeDataString(queryString);
            if (SelectedIngredients.Count != 0)
            {

            await Shell.Current.GoToAsync($"//{nameof(DisplayRecipesPage)}?query={queryString}");
            }
        }
        
        private void ExecuteAddIngredientCommand()
        {
            
            // Will be used to add a searchbar for adding personal ingredients. Later feature. 
        }

        private void ExecuteToggleVisibilityCommand()
        {
            if (IsLayoutVisible)
            {
                if (_userAddedIngredient != null)
                {
                    _ingredientStringBuilder.CreateQueryString(_userAddedIngredient);
                }
                IsLayoutVisible = false;

            }
            else
            {
                IsLayoutVisible = true;
            }


        }
    }
}
// public List<IngredientsOptions> IngredientsOption { get; } = Enum.GetValues(typeof(IngredientsOptions)).Cast<IngredientsOptions>().ToList();