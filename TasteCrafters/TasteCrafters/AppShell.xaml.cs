using System;
using System.Collections.Generic;
using System.Linq;
using TasteCrafters.ViewModels;
using TasteCrafters.Views;
using Xamarin.Forms;

namespace TasteCrafters
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // Check if navigating to the SavedRecipesPage
            if (args.Target.Location.OriginalString.Contains("SavedRecipePage"))
            {

                args.Cancel();

                // Remove SavedRecipesPage
                var navigationStack = Shell.Current.Navigation.NavigationStack.ToList();
                foreach (var page in navigationStack)
                {
                    if (page is SavedRecipesPage)
                    {
                        Shell.Current.Navigation.RemovePage(page);
                    }
                }

                // Push a new instance of SavedRecipesPage
                await Shell.Current.Navigation.PushAsync(new SavedRecipesPage());
            }
        }
    }
}
