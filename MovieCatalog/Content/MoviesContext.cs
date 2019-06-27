using MovieCatalog.Models;
using System.Data.Entity;

namespace MovieCatalog.Content
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("DefaultConnection") { }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}