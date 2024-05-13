using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TasteCrafters.Models
{
    public class IngredientGroup : ObservableCollection<IngredientModel>
    {
        public string Title { get; set; }
        public bool IsExpanded { get; set; } = true;
       // public string ImagePath { get; set; }
        public IngredientGroup(string title, ObservableCollection<IngredientModel> ingredients) : base(ingredients)
        {
            Title = title;
        }
    }
}
