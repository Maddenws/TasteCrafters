using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TasteCrafters.Models;

namespace TasteCrafters.Services
{
    public class GetIngredientListType
    {
        public ObservableCollection<IngredientModel> Meats { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Rice { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Grains { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Beans { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Fish { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Poultry { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Produce { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Fruits { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Eggs { get; } = new ObservableCollection<IngredientModel>();
        public ObservableCollection<IngredientModel> Shellfish { get; } = new ObservableCollection<IngredientModel>();

        public GetIngredientListType()
        {
            //PopulateCollection();
        }

        public void PopulateCollection()
        {
            PopulateListFromStatic(Meats, IngredientsListModel.Meats);
            PopulateListFromStatic(Rice, IngredientsListModel.Rice);
            PopulateListFromStatic(Grains, IngredientsListModel.Grains);
            PopulateListFromStatic(Beans, IngredientsListModel.Beans);
            PopulateListFromStatic(Fish, IngredientsListModel.Fish);
            PopulateListFromStatic(Poultry, IngredientsListModel.Poultry);
            PopulateListFromStatic(Produce, IngredientsListModel.Produce);
            PopulateListFromStatic(Fruits, IngredientsListModel.Fruits);
            PopulateListFromStatic(Eggs, IngredientsListModel.Eggs);
            PopulateListFromStatic(Shellfish, IngredientsListModel.Shellfish);
        }

        private void PopulateListFromStatic(ObservableCollection<IngredientModel> collection, List<string> staticList)
        {
            foreach (var item in staticList)
            {
                collection.Add(new IngredientModel { Name = item });
            }
        }

        public ObservableCollection<IngredientModel> GetTypeOfIngredient(IngredientsOptions selectedIngredient)
        {
            switch (selectedIngredient)
            {
                case IngredientsOptions.Meats:
                    return Meats;
                case IngredientsOptions.Rice:
                    return Rice;
                case IngredientsOptions.Grains:
                    return Grains;
                case IngredientsOptions.Beans:
                    return Beans;
                case IngredientsOptions.Fish:
                    return Fish;
                case IngredientsOptions.Poultry:
                    return Poultry;
                case IngredientsOptions.Produce:
                    return Produce;
                case IngredientsOptions.Fruits:
                    return Fruits;
                case IngredientsOptions.Eggs:
                    return Eggs;
                case IngredientsOptions.Shellfish:
                    return Shellfish;
                default: return null;
            }
        }
    }
}


//namespace TasteCrafters.Services
//{
//    public class GetIngredientListType : BaseViewModel, IGetIngredientListType
//    {
//        public ObservableCollection<IngredientModel> GetTypeOfIngredient(IngredientsOptions selectedIngredient)
//        {


//            switch (selectedIngredient)
//            {
//                case IngredientsOptions.Meats:
//                    return Meats;
//                case IngredientsOptions.Rice:
//                    return Rice;
//                case IngredientsOptions.Grains:
//                    return Grains;
//                case IngredientsOptions.Beans:
//                    return Beans;
//                case IngredientsOptions.Fish:
//                    return Fish;
//                case IngredientsOptions.Poultry:
//                    return Poultry;
//                case IngredientsOptions.Produce:
//                    return Produce;
//                case IngredientsOptions.Fruits:
//                    return Fruits;
//                case IngredientsOptions.Eggs:
//                    return Eggs;
//                case IngredientsOptions.Shellfish:
//                    return Shellfish;
//                default:
//                    return null;

//            }
//        }

//        public void PopulateCollection()
//        {

//            foreach (var item in IngredientsListModel.Meats)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Meats.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Rice)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Rice.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Grains)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Grains.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Beans)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Beans.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Fish)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Fish.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Poultry)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Poultry.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Produce)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Produce.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Fruits)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Fruits.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Eggs)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Eggs.Add(ingredientModel);
//            }
//            foreach (var item in IngredientsListModel.Shellfish)
//            {
//                IngredientModel ingredientModel = new IngredientModel();
//                ingredientModel.Name = item;
//                Shellfish.Add(ingredientModel);
//            }

//        }

//        private ObservableCollection<IngredientModel> _meats = new ObservableCollection<IngredientModel>();
//        public ObservableCollection<IngredientModel> Meats
//        {
//            get { return _meats; }
//            set
//            {
//                if (_meats != value)
//                {

//                    _meats = value;
//                    OnPropertyChanged(nameof(Meats));
//                }
//            }
//        }

//        private ObservableCollection<IngredientModel> _rice = new ObservableCollection<IngredientModel>();
//        public ObservableCollection<IngredientModel> Rice
//        {
//            get { return _rice; }
//            set
//            {
//                if (_rice != value)
//                {

//                    _rice = value;
//                    OnPropertyChanged(nameof(Rice));
//                }
//            }
//        }

//        private ObservableCollection<IngredientModel> _grains = new ObservableCollection<IngredientModel>();
//        public ObservableCollection<IngredientModel> Grains
//        {
//            get { return _grains; }
//            set
//            {
//                if (_grains != value)
//                {

//                    _grains = value;
//                    OnPropertyChanged(nameof(Grains));
//                }
//            }
//        }
//        //ObservableCollection<IngredientModel> Meats = new ObservableCollection<IngredientModel>();

//        //ObservableCollection<IngredientModel> Rice = new ObservableCollection<IngredientModel>();

//        //ObservableCollection<IngredientModel> Grains = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Beans = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Fish = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Poultry = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Produce = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Fruits = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Eggs = new ObservableCollection<IngredientModel>();

//        ObservableCollection<IngredientModel> Shellfish = new ObservableCollection<IngredientModel>();
//    }

//}
