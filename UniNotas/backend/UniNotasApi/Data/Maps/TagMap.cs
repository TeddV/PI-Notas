using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniNotasApi.Models;

namespace UniNotasApi.Data.Maps
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                   .HasMaxLength(1024)
                   .HasColumnType("varchar(1024)");
            builder.HasOne(x => x.Book)
                   .WithOne(x => x.Tag);
        }
    }
}