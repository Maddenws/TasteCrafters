using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace TasteCrafters.Services
{
    public class DatabaseFinder
    {
        public static List<string> FindAllDatabases()
        {
            var appDataDirectory = FileSystem.AppDataDirectory;
            var databaseFiles = Directory.GetFiles(appDataDirectory, "*.db");

            return databaseFiles.ToList();
        }
    }
}
