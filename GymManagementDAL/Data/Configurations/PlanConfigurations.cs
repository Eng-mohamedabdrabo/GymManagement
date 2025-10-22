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
    internal class PlanConfigurations : IEntityTypeConfiguration<Plans>
    {
        public void Configure(EntityTypeBuilder<Plans> builder)
        {
            builder.Property(X => X.Name)
                .HasColumnType("varchar(50)");

            builder.Property(X => X.Description)
                .HasColumnType("varchar(100)");

            builder.Property(X => X.Price)
                .HasPrecision(10,2);

            builder.ToTable(Tb => Tb.HasCheckConstraint(
                "DurationDaysConstraint",
                 "DurationDays between 1 and 365"
                )
            );
        }
    }
}
