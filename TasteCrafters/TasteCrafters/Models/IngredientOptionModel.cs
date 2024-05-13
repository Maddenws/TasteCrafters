using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TasteCrafters.Models
{
    public class IngredientOptionModel
    {
        public Options Option { get; set; }

        public enum Options
        {

            [Description("Meats")]
            Meats,

            [Description("Rice")]
            Rice,

            [Description("Grains")]
            Grains,

            [Description("Beans")]
            Beans,

            [Description("Fish")]
            Fish,

            [Description("Poultry")]
            Poultry,

            [Description("Produce")]
            Produce,

            [Description("Fruits")]
            Fruits,

            [Description("Eggs")]
            Eggs,

            [Description("Shellfish")]
            Shellfish
        }
    }
}
