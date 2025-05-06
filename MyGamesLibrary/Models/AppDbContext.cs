using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MyGamesLibrary.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Played> playedGames { get; set; }
        public DbSet<WantsToPlay> wantsToPlayGames {  get; set; }
        public DbSet<Favourite> FavGames { get; set; }

        public AppDbContext() : base()
        {
            
        }
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GamesClone2;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
