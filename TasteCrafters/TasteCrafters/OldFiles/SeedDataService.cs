using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteCrafters.Models;

namespace TasteCrafters.Services
{
    public class SeedDataService
    {
        public static async Task SeedData() 
        {
            await DataAcessService.Init();

            await SeedMeatData();
            await SeedSeafoodData();
            await SeedProduceData();
            await SeedPoultryData();
            await SeedRiceAndGrainsData();
            await SeedBeansAndLegumesData();
        }

        private static async Task SeedMeatData()
        {
            if (await DataAcessService.IsTableEmpty<MeatModel>())
            {
                var meats = DataInitializer.Meats;

                var meatModels = meats.Select(meatName => new MeatModel
                {
                    MeatType = meatName

                }).ToList();

                await DataAcessService.InsertItemsAsync(meatModels);
 
            }
        }

        private static async Task SeedSeafoodData()
        {

            if (await DataAcessService.IsTableEmpty<SeafoodModel>())
            {
                var seafoods = DataInitializer.Seafood;

                var seafoodModels = seafoods.Select(SeafoodName => new SeafoodModel
                {
                    SeafoodType = SeafoodName

                }).ToList();

                await DataAcessService.InsertItemsAsync(seafoodModels);
            }
        }

        private static async Task SeedProduceData()
        {
            if (await DataAcessService.IsTableEmpty<ProduceModel>())
            {
                var produces = DataInitializer.Produce;

                var produceModel = produces.Select(produceName => new ProduceModel
                {
                    ProduceType = produceName

                }).ToList();

                await DataAcessService.InsertItemsAsync(produceModel);
            }
        }

        private static async Task SeedPoultryData()
        {
            if (await DataAcessService.IsTableEmpty<PoultryModel>())
            {
                var poultrys = DataInitializer.Seafood;

                var poultryModels = poultrys.Select(poultryName => new SeafoodModel
                {
                    SeafoodType = poultryName

                }).ToList();

                await DataAcessService.InsertItemsAsync(poultryModels);
            }
        }

        private static async Task SeedRiceAndGrainsData()
        {
            if (await DataAcessService.IsTableEmpty<RiceAndGrainsModel>())
            {
                var riceAndGrains = DataInitializer.Seafood;

                var riceAndGrainsModel = riceAndGrains.Select(riceAndGrainNames => new RiceAndGrainsModel
                {
                    RiceAndGrainsType = riceAndGrainNames

                }).ToList();

                await DataAcessService.InsertItemsAsync(riceAndGrainsModel);
            }
        }

        private static async Task SeedBeansAndLegumesData()
        {
            if (await DataAcessService.IsTableEmpty<SeafoodModel>())
            {
                var seafood = DataInitializer.Seafood;

                var seafoodModels = seafood.Select(SeafoodName => new SeafoodModel
                {
                    SeafoodType = SeafoodName

                }).ToList();

                await DataAcessService.InsertItemsAsync(seafoodModels);
            }
        }
    }
}
