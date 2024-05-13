using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasteCrafters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayRecipesPage : ContentPage
    {
        public DisplayRecipesPage()
        {
            InitializeComponent();
           // BindingContext = new DisplayRecipesPage();
        }
    }
}