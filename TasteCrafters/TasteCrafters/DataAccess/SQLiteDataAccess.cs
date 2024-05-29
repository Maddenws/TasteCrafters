using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TasteCrafters.Services;

namespace TasteCrafters.DataAccess
{
    public class SQLiteDataAccess : IDataAccess
    {
        private SQLiteConnection _connection;

        //private ObservableCollection<SavedRecipeModel> _savedRecipes;

        public string StatusMessage { get; set; }
        public SQLiteDataAccess(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<SavedRecipeModel>();
            //DatabaseDropper.DropDatabase("TasteCrafters.db3");
        }

        public void AddNewRecipe(SavedRecipeModel recipe)
        {
            try
            {
                if (recipe == null)
                {
                    throw new ArgumentNullException(nameof(recipe));

                }
                var result = _connection.Insert(recipe);
                StatusMessage = $"{result} record(s) added [Recipe: {recipe.Title}].";
            }
            catch (Exception ex)
            {

                StatusMessage = $"Failed to add {recipe.Title}. Error: {ex.Message}";
            }
        }

        public List<SavedRecipeModel> GetAllRecipes()
        {
            try
            {
                return _connection.Table<SavedRecipeModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
                return new List<SavedRecipeModel>();
            }
        }

        public void DeleteRecipe(int id)
        {
            try
            {
                var result = _connection.Delete<SavedRecipeModel>(id);
                StatusMessage = $"{result} record(s) deleted.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to delete. Error: {ex.Message}";
            }
        }
    }
}
