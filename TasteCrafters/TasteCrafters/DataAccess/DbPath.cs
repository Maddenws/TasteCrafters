using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TasteCrafters.DataAccess
{
    public static class DbPath
    {
        public static string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TasteCrafters.db3");
        }
    }
}
