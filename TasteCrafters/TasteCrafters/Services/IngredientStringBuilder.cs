using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TasteCrafters.Models;

namespace TasteCrafters.ViewModels
{
    public class IngredientStringBuilder : IIngredientStringBuilder
    {
        private StringBuilder _stringBuilder;
        //private readonly ObservableCollection<IngredientModel> _selectedIngredients;
        public IngredientStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public void AddIngredient(string ingredient)
        {
            _stringBuilder.Append(ingredient);

           
            if (_stringBuilder.Length > 0)
            {
                _stringBuilder.Append(", ");
            }
        }


        public void CreateQueryString(ObservableCollection<IngredientModel> ingredients)
        {
            foreach (var item in ingredients)
            {
                AddIngredient(item.Name);
            }
        }
        
        public void CreateQueryString(string input)
        {
            AddIngredient(input);
        }
        public string GetString()
        {
            
            return _stringBuilder.ToString();
        }
    }
}