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
    internal class SessionConfigurations : IEntityTypeConfiguration<Sessions>
    {
        public void Configure(EntityTypeBuilder<Sessions> builder)
        {
            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CapacityCheckConstraint", "Capacity between 1 and 25");
                Tb.HasCheckConstraint("StartDateConstraint", "EndDate > StartDate");
            }
            );
        }
    }
}
