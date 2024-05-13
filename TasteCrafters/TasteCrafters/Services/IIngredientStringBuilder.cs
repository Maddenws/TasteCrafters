namespace TasteCrafters.ViewModels
{
    public interface IIngredientStringBuilder
    {
        void AddIngredient(string ingredient);
        string GetString();
    }
}