using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniNotasApi.Models;

namespace UniNotasApi.Data.Maps
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnType("varchar(80)");
            builder.HasOne(x => x.Tag)
                   .WithOne(x => x.Book);

        }
    }
}