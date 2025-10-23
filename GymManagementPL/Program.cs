using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Reposetories.implementation;
using GymManagementDAL.Reposetories.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymManagementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<GymDbContexts>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionString")["DefaultConnection"];   //First Way \\
                //options.UseSqlServer(builder.Configuration.["ConnectionString:DefaultConnection"];               // Second Way \\
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));        //3rd way and most common used  \\
            });

            builder.Services.AddScoped(typeof(IGenericRepositoryInterface<>), typeof(GenericRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
