using System.Collections.Generic;
using TasteCrafters.Models;

namespace TasteCrafters.Services
{
    public interface IDataAccessService
    {
        List<BeansAndLegumesModel> GetbeansAndLegumes();
        List<MeatModel> GetMeats();
        List<PoultryModel> GetPoultry();
        List<ProduceModel> GetProduce();
        List<RiceAndGrainsModel> GetRiceAndGrains();
        List<SeafoodModel> GetSeafood();
        List<string> GetAllTables();
    }
}