using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteCrafters.Models;
using TasteCrafters.Services;
using TasteCrafters.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasteCrafters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        //private void MyCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (BindingContext is MainPageViewModel vm)
        //    {
        //        vm.SelectedIngredient = new ObservableCollection<IngredientModel>();
        //        foreach (var item in e.CurrentSelection)
        //        {
        //            if (item is IngredientModel selectedItem)
        //            {
        //                vm.SelectedIngredient.Add(selectedItem);
        //                //if (!vm.SelectedIngredient.Contains(selectedItem))
        //                //{
        //                //    vm.SelectedIngredient.Add(selectedItem);
        //                //}
                        
        //                //IngredientModel ingredientModel = new IngredientModel();
        //                //ingredientModel.Name = selectedItem;
        //                //ingredientModel.IsSelected = true;
        //                //vm.SelectedIngredient.Add(ingredientModel);
        //                //if (selectedItem.IsSelected)
        //                //{
        //                //    selectedItem.IsSelected = false;
        //                //}
        //                //else
        //                //{
        //                //    selectedItem.IsSelected = true;
        //                //    vm.SelectedIngredient.Add(selectedItem);
        //                //}
        //            }

        //        }
        //    }

        //}
    }
}