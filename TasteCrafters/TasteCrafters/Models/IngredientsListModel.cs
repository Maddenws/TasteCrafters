using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TasteCrafters.Models
{
    public static class IngredientsListModel
    {
        public static List<string> Meats { get; } = new List<string>
        {
        "American Bison", "Antelope", "Barbary Sheep", "Beef", "Bighorn Sheep", "Boar",
        "Bushpig", "Caraba", "Caribou", "Deer", "goat", "Goat", "Lamb", "Moose",
        "Opossum", "Peccary", "Pika", "Pork", "Rabbit", "Red River Hog", "Sheep", "Veal", "Yak"
        };

        public static List<string> Rice { get; } = new List<string>
        {
         "Rice",
         "Brown rice",
         "White rice",
         "Jasmine rice",
         "Yellow rice"
        };
        public static List<string> Grains { get; } = new List<string>
        {
         "Amaranth","Barley","Bread","Buckwheat","Bulgur","Corn","Cornmeal","Crackers","Millet",
         "Oatmeal","Pasta","Popcorn","Quinoa","Rolled oats","rye","Sorghum","tortillas","Triticale"
};
        public static List<string> Beans { get; } = new List<string>
        {
         "Aduke Beans","Anasazi Beans","Azuki Beans","Black Beans","Black-Eyed Peas","Broad Beans",
         "Calypso","Cannellini Beans","Copper Beans","Fava Beans","Garbanzo Beans","Kidney Beans","Lima Beans",
         "Mung Beans","Navy Beans","Northern Beans","Peanuts","Pinto Beans","Red Beans","Soy Beans",
         "Soy Beans, Black","Soy Beans, Red","Speckled Cranberry Beans","Tamarind Beans","White Beans"
        };

        public static List<string> Fish { get; } = new List<string>
        {
         "Seafood","Anchovy","Basa","Bass","Carp","Catfish","Cod","CrappieEel","Flounder","Grouper","Haddock","Halibut","Herring","Kingfish",
         "Mackerel","Mahi Mahi","Marlin","Orange Roughy","Perch","Pike","Pollock","Salmon","Sardine","Snapper","Sole","Swordfish","Tilapia",
         "Trout","Tuna","Walleye",
        };

        public static List<string> Poultry { get; } = new List<string>
        {
         "Poultry","Chicken","Cornish Hen","Dove","Duck","Emu","Goose","Grouse","Guinea fowl","Ostrich","Partridge","Pheasant","Pigeon","Quail",
         "Turkey",
        };
        public static List<string> Produce { get; } = new List<string>
        {
         "Produce","Artichokes","Artichokes","Asparagus","Avocados","Bell peppers","Broccoli","Brussels sprouts","Cabbage","Carrots","Cauliflower",
         "Celery","Chard","Cilantro","Collard greens","Cucumbers","Eggplant","Escarole","Garlic","Gingerroot","Green beans","kale","Lettuce","Mushrooms",
         "Mustard greens","Okra","Onions","Parsley","Peppers","Potatoes","Pumpkin","Radishes","Scallions","Spinach","Squash","Sweet-potatoes","Thyme","Tomatoes",
         "Turnip greens"
        };

        public static List<string> Fruits { get; } = new List<string>
        {
         "Apple","Apricot","Apricot lassi","Banana","Blueberry","Cherry","Durian","Feijoa","Fig","Grape","Grapefruit","Guava","Honeydew",
         "Kiwifruit","Lemon","Lime","Longan","Lychee","Mandarin","Mango","Mangosteen","Melon platter","Nashi","Nectarine","Orange","Passionfruit","Pawpaw","Peach","Pear",
         "Persimmon","Pineapple","Plum","Poached pears","Pomegranate","Pomelo","Rambutan","Raspberry","Rhubarb","Rockmelon","Star fruit","Strawberry","Tamarillo","Tangelo","Watermelon"
        };

        public static List<string> Eggs { get; } = new List<string>
        {
            "Chicken Eggs","Duck Eggs","Goose Eggs","Hen Eggs","Quail Eggs",
        };

        public  static List<string> Shellfish { get; } = new List<string>
        {
         "Abalone","Clam","Conch","Crab","Crayfish","Cuttlefish","Lobster","Loc","Mussel","Octopus",
         "Oyster","Prawn","Scallop","Shrimp","Snail"
        };
    }
}
