using System;
using TasteCrafters.DataAccess;
using TasteCrafters.Services;
using TasteCrafters.ViewModels;
using TasteCrafters.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasteCrafters
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            DependencyService.RegisterSingleton(new GetIngredientListType());
            DependencyService.RegisterSingleton(new IngredientStringBuilder());
            DependencyService.Register<GetIngredientListType>();
            DependencyService.Register<IngredientStringBuilder>();
            DependencyService.RegisterSingleton<IDataAccess>(new SQLiteDataAccess(DbPath.GetDatabasePath()));
            //DependencyService.RegisterSingleton(new DataAccessService());
            //DependencyService.RegisterSingleton(new DataAccess());
            //DependencyService.RegisterSingleton<IDatabaseHelper>(new DatabaseHelper());
            //DependencyService.RegisterSingleton<IDataAccess>(new SqliteDbAccess());
            
            
            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
