using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TasteCrafters.Models;

namespace TasteCrafters.DataAccess
{
    public class SavedRecipeModel : SearchResultModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
