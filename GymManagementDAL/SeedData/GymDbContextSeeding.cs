using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagementDAL.SeedData
{
    public static class GymDbContextSeeding
    {
        public static bool SeedData(GymDbContexts dbContext)
        {
            try
            {
                var hasPlans = dbContext.Plans.Any();
                var hasCategories = dbContext.Categories.Any();

                if (hasPlans && hasCategories)
                    return false;

                if (!hasPlans)
                {
                    var plans = LoadDataFromJson<Plans>("plans.json");
                    if (plans.Any())
                        dbContext.Plans.AddRange(plans);
                }

                if (!hasCategories)
                {
                    var categories = LoadDataFromJson<Categories>("categories.json");
                    if (categories.Any())
                        dbContext.Categories.AddRange(categories);
                }

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while seeding data: {ex.Message}");
                return false;
            }
        }


        private static List<T> LoadDataFromJson<T>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", fileName);

            if (!File.Exists(filePath))
                return new List<T>();



            var json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }
    }
}
