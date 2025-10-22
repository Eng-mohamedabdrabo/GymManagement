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
    internal class TrainerConfigurations :GymUserConfiguration<Trainers>, IEntityTypeConfiguration<Trainers>
    {
        public new void Configure(EntityTypeBuilder<Trainers> builder)
        {
            builder.Property(X => X.CreatedAt)
                .HasColumnName("HireDate")
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(T => T.Sessions).WithOne(S => S.Trainers)
                .HasForeignKey(S => S.TrainersId);


            base.Configure(builder);
        }
    }
}
