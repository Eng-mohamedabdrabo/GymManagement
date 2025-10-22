using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.Contexts
{
    internal class GymDbContexts : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Members> Members { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<HealthRecords> HealthRecords { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<MemberSessions> MemberSessions { get; set; }
    }
}
