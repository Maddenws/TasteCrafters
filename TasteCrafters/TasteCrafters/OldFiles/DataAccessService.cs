using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TasteCrafters.Models;
using static Xamarin.Essentials.Permissions;

namespace TasteCrafters.Services
{
    public class DataAccessService : IDataAccessService
    {
        public DataAccessService()
        {

        }

        public List<MeatModel> GetMeats()
        {
            List<string> meats = new List<string>
            {
            "Meats","American Bison","Antelope","Barbary Sheep","Beef","Bighorn Sheep","Boar","Bushpig","Capybara","Caraba","Caribou","Deer","goat","Goat","Lamb","Moose","Opossum","Peccary","Pika","Pork","Rabbit","Red River Hog","Sheep","Veal","Yak"
            };

            List<MeatModel> meatModels = new List<MeatModel>();

            foreach (var item in meats)
            {
                meatModels.Add(new MeatModel { MeatType = item });
            }
            return meatModels;
        }
        public List<RiceAndGrainsModel> GetRiceAndGrains()
        {
            List<string> riceAndGrains = new List<string>
            {
            "Rice & Grains","Amaranth","Barley","Bread","Brown rice","Buckwheat","Bulgur","Corn","Cornmeal","Crackers","Millet","Oatmeal","Pasta","Popcorn","Quinoa","White rice","Rolled oats","rye","Sorghum","tortillas","Triticale"
            };

            List<RiceAndGrainsModel> riceAndGrainsModels = new List<RiceAndGrainsModel>();

            foreach (var item in riceAndGrains)
            {
                riceAndGrainsModels.Add(new RiceAndGrainsModel { RiceAndGrainsType = item });
            }
            return riceAndGrainsModels;
        }
        public List<BeansAndLegumesModel> GetbeansAndLegumes()
        {
            List<string> beanAndLegumes = new List<string>
            {
            "Beans & Legumes","Aduke Beans","Alfalfa","Anasazi Beans","Azuki Beans","Bean Sprouts","Beans, Snap","Black Beans","Black-Eyed Peas","Broad Beans","Calypso","Cannellini Beans","Copper Beans","Edamame","Fava Beans","Garbanzo Beans","Green Beans","Jicama","Kidney Beans","Lentils","Lentils, Green,","Lentils, Yellow","Lima Beans","Mung Beans","Navy Beans","Northern Beans","Pea Pods","Peanuts","Peas, Green","Pinto Beans","Red Beans","Soy Beans","Soy Beans, Black","Soy Beans, Red","Speckled Cranberry Beans","Tamarind Beans","Wax Beans","White Beans"
            };

            List<BeansAndLegumesModel> beansAndLegumesModel = new List<BeansAndLegumesModel>();

            foreach (var item in beanAndLegumes)
            {
                beansAndLegumesModel.Add(new BeansAndLegumesModel { BeansAndLegumesType = item });
            }
            return beansAndLegumesModel;
        }
        public List<SeafoodModel> GetSeafood()
        {
            List<string> seafood = new List<string>
            {
            "Seafood","Anchovy","Basa","Bass","Carp","Catfish","Cod","CrappieEel","Flounder","Grouper","Haddock","Halibut","Herring","Kingfish","Mackerel","Mahi Mahi","Marlin","Orange Roughy","Perch","Pike","Pollock","Salmon","Sardine","Snapper","Sole","Swordfish","Tilapia","Trout","Tuna","Walleye","**Shellfish**","Abalone","Clam","Conch","Crab","Crayfish","Cuttlefish","Lobster","Loc","Mussel","Octopus","Oyster","Prawn","Scallop","Shrimp","Snail"
            };

            List<SeafoodModel> seafoodModels = new List<SeafoodModel>();

            foreach (var item in seafood)
            {
                seafoodModels.Add(new SeafoodModel { SeafoodType = item });
            }
            return seafoodModels;
        }
        public List<PoultryModel> GetPoultry()
        {
            List<string> poultry = new List<string>
            {
            "Poultry","Chicken","Cornish Hen","Dove","Duck","Emu","Goose","Grouse","Guinea fowl","Ostrich","Partridge","Pheasant","Pigeon","Quail","Turkey","**Eggs**","Chicken Eggs","Duck Eggs","Goose Eggs","Hen Eggs","Quail Eggs",
            };

            List<PoultryModel> poultrymodels = new List<PoultryModel>();

            foreach (var item in poultry)
            {
                poultrymodels.Add(new PoultryModel { PoultryType = item });
            }
            return poultrymodels;
        }
        public List<ProduceModel> GetProduce()
        {
            List<string> produce = new List<string>
            {
            "Produce","Artichokes","Artichokes","Asparagus","Avocados","Bell peppers","Broccoli","Brussels sprouts","Cabbage","Carrots","Cauliflower","Celery","Chard","Cilantro","Collard greens","Cucumbers","Eggplant","Escarole","Garlic","Gingerroot","Green beans","kale","Lettuce","Mushrooms","Mustard greens","Okra","Onions","Parsley","Peppers","Potatoes","Pumpkin","Radishes","Scallions","Spinach","Squash","Sweet-potatoes","Thyme","Tomatoes","Turnip greens","**Fruits**","Apple","Apricot","Apricot lassi","Banana","Blueberry","Cherry","Durian","Feijoa","Fig","Grape","Grapefruit","Guava","Honeydew","Kiwifruit","Lemon","Lime","Longan","Lychee","Mandarin","Mango","Mangosteen","Melon platter","Nashi","Nectarine","Orange","Passionfruit","Pawpaw","Peach","Pear","Persimmon","Pineapple","Plum","Poached pears","Pomegranate","Pomelo","Rambutan","Raspberry","Rhubarb","Rockmelon","Star fruit","Strawberry","Tamarillo","Tangelo","Watermelon"
            };

            List<ProduceModel> produceModels = new List<ProduceModel>();

            foreach (var item in produce)
            {
                produceModels.Add(new ProduceModel { ProduceType = item });
            }
            return produceModels;
        }

        public List<string> GetAllTables()
        {
            List<string> tables = new List<string> { nameof(MeatModel), nameof(RiceAndGrainsModel), nameof(BeansAndLegumesModel), nameof(SeafoodModel), nameof(PoultryModel), nameof(ProduceModel) };
            return tables;
        }
    }
}
