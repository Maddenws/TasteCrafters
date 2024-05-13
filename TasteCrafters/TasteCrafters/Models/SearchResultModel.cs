using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TasteCrafters.Models
{
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public object ImageUrl { get; internal set; }
    }
}
