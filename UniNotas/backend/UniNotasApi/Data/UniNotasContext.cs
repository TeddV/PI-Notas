using Microsoft.EntityFrameworkCore;
using UniNotasApi.Data.Maps;
using UniNotasApi.Models;

namespace UniNotasApi.Data
{
    public class UniNotasContext : DbContext
    {
        public UniNotasContext(DbContextOptions<UniNotasContext> options) : base(options)
        {

        }

        public DbSet<Book> books { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<User> users { get; set; } 
      protected override void OnModelCreating(ModelBuilder builder)
       {
           builder.ApplyConfiguration(new BookMap());
           builder.ApplyConfiguration(new NoteMap());
           builder.ApplyConfiguration(new TagMap());
           builder.ApplyConfiguration(new UserMap());
       }  

    }
}