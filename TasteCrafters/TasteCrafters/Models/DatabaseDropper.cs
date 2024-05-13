using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace TasteCrafters.Models
{
    public class DatabaseDropper
    {
        public static void DropDatabase(string databaseName)
        {
            var appDataDirectory = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(appDataDirectory, databaseName);

            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }
        }
    }
}
