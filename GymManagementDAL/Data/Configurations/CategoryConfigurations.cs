using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.Configurations
{
    internal class CategoryConfigurations : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.Property(X => X.CategoryName)
                .HasColumnType("varchar(20)");

            builder.HasMany(C => C.Sessions).WithOne(S => S.Categories)
                .HasForeignKey(S => S.CategoriesId);
        }
    }
}
