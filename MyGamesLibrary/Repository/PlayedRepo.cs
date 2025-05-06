using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public class PlayedRepo : IPlayedRepo
    {
        AppDbContext context;
        public PlayedRepo(AppDbContext context)
        {
            this.context = context;   
        }
        public void Add(Played game)
        {
            context.Add(game);
        }
        public void update(Played game)
        {
            context.Update(game);
        }
        public void Delete(string Name)
        {
            Played game = GetByName(Name);
            context.Remove(game);
        }

        public List<Played> GetAll()
        {
            return context.playedGames.ToList();
        }

        public Played GetByName(string Name)
        {
            return context.playedGames.FirstOrDefault(x => x.Name == Name);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
