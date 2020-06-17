using Microsoft.EntityFrameworkCore;

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
      protected override void OnModelCreating(ModelBuilder builder)
       {
        
       }  

    }
}