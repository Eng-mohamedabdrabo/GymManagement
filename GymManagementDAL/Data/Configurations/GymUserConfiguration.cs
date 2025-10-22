using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUsers
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Phone)
                .HasColumnType("varchar(11)");

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("EmailValidFormatConstraint", "Email like '_%@_%._%'");
                tb.HasCheckConstraint("PhoneFormatConstraint", "Phone like '01[0125]%' AND Phone not like '%[^0-9]%'");
            });

            builder.OwnsOne(x => x.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Street)
                    .HasColumnType("varchar(30)");

                addressBuilder.Property(a => a.City)
                    .HasColumnType("varchar(30)");
            });
        }
    }
}
