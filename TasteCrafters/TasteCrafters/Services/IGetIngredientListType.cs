using System.Collections.ObjectModel;
using TasteCrafters.Models;

namespace TasteCrafters.Services
{
    public interface IGetIngredientListType
    {
        ObservableCollection<IngredientModel> GetTypeOfIngredient(IngredientsOptions selectedIngredient);
        void PopulateCollection();
    }
}