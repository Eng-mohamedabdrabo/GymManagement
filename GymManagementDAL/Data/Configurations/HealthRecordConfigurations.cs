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
    internal class HealthRecordConfigurations : IEntityTypeConfiguration<HealthRecords>
    {
        public void Configure(EntityTypeBuilder<HealthRecords> builder)
        {
            builder.ToTable("Members").HasKey(X => X.Id);

            builder.HasOne<Members>().WithOne(X => X.HealthRecords)
                .HasForeignKey<HealthRecords>(X => X.Id);

            builder.Ignore(HR => HR.CreatedAt);

        }
    }
}
