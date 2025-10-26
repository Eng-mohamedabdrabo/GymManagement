using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Reposetories.implementation;
using GymManagementDAL.Reposetories.interfaces;
using GymManagementDAL.SeedData;
using GymManagementDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GymManagementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services Configuration (Dependency Injection)

            // Add MVC Controllers & Views
            builder.Services.AddControllersWithViews();

            // Register DbContext with SQL Server
            builder.Services.AddDbContext<GymDbContexts>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register UnitOfWork and Repositories
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // builder.Services.AddScoped(typeof(IGenericRepositoryInterface<>), typeof(GenericRepository<>));
            // builder.Services.AddScoped<IPlansInterface, PlanRepository>();

            #endregion

            var app = builder.Build();

            #region Database Migration & Seeding

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GymDbContexts>();

                // Apply pending migrations automatically
                var pendingMigrations = dbContext.Database.GetPendingMigrations();
                if (pendingMigrations?.Any() ?? false)
                {
                    dbContext.Database.Migrate();
                }

                // Seed initial data (if not already seeded)
                GymDbContextSeeding.SeedData(dbContext);
            }

            #endregion

            #region HTTP Request Pipeline Configuration

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}
