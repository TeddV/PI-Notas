using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniNotasApi.Models;

namespace UniNotasApi.Data.Maps
{
    public class NoteMap : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Note");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Image)
                   .HasMaxLength(1024)
                   .HasColumnType("varchar(1024)");
            builder.Property(x => x.Text)
                   .HasMaxLength(512)
                   .HasColumnType("varchar(1024)");
            builder.Property(x => x.Video)
                   .HasMaxLength(1024)
                   .HasColumnType("varchar(1024)");
            builder.Property(x => x.Audio)
                   .HasMaxLength(1024)
                   .HasColumnType("varchar(1024)");
            builder.Property(x => x.CreateDate)
                   .IsRequired();
            builder.Property(x => x.LastUpdateDate)
                   .IsRequired();
            builder.HasOne(x => x.Book).WithMany(x => x.Notes);
       
        }
    }
}