using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TasteCrafters.Models;

namespace TasteCrafters.Services
{
    public class IngredientSelection:INotifyPropertyChanged
    {
        private IngredientsOptions _ingredientType;
        public IngredientsOptions IngredientType
        {
            get { return _ingredientType; }
            set
            {
                if (_ingredientType != value)
                {
                    _ingredientType = value;
                    OnPropertyChanged(nameof(IngredientType));
                }
            }
        }

        private string _selectedIngredient;
        public string SelectedIngredient
        {
            get { return _selectedIngredient; }
            set
            {
                if (_selectedIngredient != value)
                {
                    _selectedIngredient = value;
                    OnPropertyChanged(nameof(SelectedIngredient));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
