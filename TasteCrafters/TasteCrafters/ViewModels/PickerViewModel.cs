using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using TasteCrafters.Models;
using TasteCrafters.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TasteCrafters.ViewModels
{
    public class PickerViewModel : INotifyPropertyChanged
    {
        private IIngredientStringBuilder _ingredientStringBuilder =>
            DependencyService.Get<IIngredientStringBuilder>();
        public PickerViewModel()
        {
            SelectedIngredientType = IngredientsOption.FirstOrDefault();
            //_ingredientStringBuilder = new IngredientStringBuilder();
            //_ingredientList = new ObservableCollection<string>();
            
            CancelPickerTappedCommand = new Command(ExecutePickerTappedCommand);
            
        }

        private ObservableCollection<string> _ingredientList;
       // private IngredientStringBuilder _ingredientStringBuilder;

        private IngredientsOptions _selectedIngredientType;
        public IngredientsOptions SelectedIngredientType
        {
            get { return _selectedIngredientType; }
            set
            {
                if (_selectedIngredientType != value)
                {
                    _selectedIngredientType = value;
                    // Clear the existing list and add new items
                    IngredientList.Clear();
                    ////var newItems = GetIngredientListType.GetTypeOfIngredient(value);
                    //foreach (var item in newItems)
                    //{
                    //  // IngredientList.Add(item);
                    //}
                    OnPropertyChanged(nameof(SelectedIngredientType));
                }
            }
        }

        public ObservableCollection<string> IngredientList
        {
            get
            {
                return _ingredientList;
            }
            set
            {
                if (_ingredientList != value)
                {
                    _ingredientList = value;
                    OnPropertyChanged(nameof(IngredientList));
                }
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    
                    _selectedItem = value;
                    _ingredientStringBuilder.AddIngredient(_selectedItem);
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ICommand CancelPickerTappedCommand { get; set; }
        public event EventHandler CancelButtonTapped;
        public void ExecutePickerTappedCommand()
        {
            
            //CancelButtonTapped?.Invoke(this, EventArgs.Empty);
        }

        public List<IngredientsOptions> IngredientsOption { get; } = Enum.GetValues(typeof(IngredientsOptions)).Cast<IngredientsOptions>().ToList();

    }
}
