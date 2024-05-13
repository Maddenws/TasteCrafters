using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TasteCrafters.Models;
using TasteCrafters.Services;
using Xamarin.Forms;

namespace TasteCrafters.Db
{
    public class DataAccess : IDataAccess
    {
        private IDataAccessService DataAccessService => DependencyService.Get<IDataAccessService>();

        SQLiteConnection sqlitConnection;
        public DataAccess()
        {
            sqlitConnection = CreateConnection();
            CreateAllTables();
            //DropAllTables();
        }
        private SQLite.SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "TasteCrafters.db";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            return new SQLite.SQLiteConnection(path);
        }
        public void CreateMeatTable()
        {
            sqlitConnection.CreateTable<MeatModel>();
            List<MeatModel> meats = DataAccessService.GetMeats();
            foreach (var item in meats)
            {
                sqlitConnection.Insert(item);
            }

        }
        public void CreateSeafoodTable()
        {
            sqlitConnection.CreateTable<SeafoodModel>();
            List<SeafoodModel> seafood = DataAccessService.GetSeafood();
            foreach (var item in seafood)
            {
                sqlitConnection.Insert(item);
            }
        }
        public void CreatePoultryTable()
        {
            sqlitConnection.CreateTable<PoultryModel>();
            List<PoultryModel> poultry = DataAccessService.GetPoultry();
            foreach (var item in poultry)
            {
                sqlitConnection.Insert(item);
            }
        }
        public void CreateRiceAndGrainTable()
        {
            sqlitConnection.CreateTable<RiceAndGrainsModel>();
            List<RiceAndGrainsModel> riceAndGrains = DataAccessService.GetRiceAndGrains();
            foreach (var item in riceAndGrains)
            {
                sqlitConnection.Insert(item);
            }
        }
        public void CreateBeansAndLegumeTable()
        {
            sqlitConnection.CreateTable<BeansAndLegumesModel>();
            List<BeansAndLegumesModel> beansAndLegumes = DataAccessService.GetbeansAndLegumes();
            foreach (var item in beansAndLegumes)
            {
                sqlitConnection.Insert(item);
            }
        }
        public void CreateProduceTable()
        {
            sqlitConnection.CreateTable<ProduceModel>();
            List<ProduceModel> produce = DataAccessService.GetProduce();
            var tableInfo = sqlitConnection.GetTableInfo(nameof(ProduceModel));
            foreach (var item in produce)
            {
                sqlitConnection.Insert(item);
            }
        }
        public void CreateAllTables()
        {
            List<string> tableNames = DataAccessService.GetAllTables();
            foreach (var item in tableNames)
            {
                switch (item)
                {
                    case nameof(MeatModel):
                        if (!DoesTableExist(item))
                        {
                            CreateMeatTable();
                        }
                        break;
                    case nameof(SeafoodModel):
                        if (!DoesTableExist(item))
                        {
                            CreateSeafoodTable();
                        }
                        break;
                    case nameof(PoultryModel):
                        if (!DoesTableExist(item))
                        {
                            CreatePoultryTable();
                        }
                        break;
                    case nameof(RiceAndGrainsModel):
                        if (!DoesTableExist(item))
                        {
                            CreateRiceAndGrainTable();
                        }
                        break;
                    case nameof(BeansAndLegumesModel):
                        if (!DoesTableExist(item))
                        {
                            CreateBeansAndLegumeTable();
                        }
                        break;
                    case nameof(ProduceModel):
                        if (!DoesTableExist(item))
                        {
                            CreateProduceTable();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private bool DoesTableExist(string tableName)
        {
            return sqlitConnection.GetTableInfo(tableName).ToList().Count > 0;
        }

        private void DropAllTables()
        {
            sqlitConnection.DropTable<MeatModel>();
            sqlitConnection.DropTable<SeafoodModel>();
            sqlitConnection.DropTable<PoultryModel>();
            sqlitConnection.DropTable<RiceAndGrainsModel>();
            sqlitConnection.DropTable<BeansAndLegumesModel>();
            sqlitConnection.DropTable<ProduceModel>();
        }
    }
}
