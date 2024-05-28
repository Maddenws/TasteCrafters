using System.Collections.Generic;

namespace TasteCrafters.DataAccess
{
    public interface IDataAccess
    {
        string StatusMessage { get; set; }

        void AddNewRecipe(SavedRecipeModel recipe);
        void DeleteRecipe(int id);
        List<SavedRecipeModel> GetAllRecipes();
    }
}