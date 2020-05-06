using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniNotasApi.Models;

namespace UniNotasApi.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username)
                   .IsRequired().HasColumnType("varchar(80)");
;
            builder.Property(x => x.Password)
                   .IsRequired().HasColumnType("varchar(16)");
        }
    }
}