using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public class WantedRepo : IWantedRepo
    {
        AppDbContext context;
        public WantedRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(WantsToPlay game)
        {
            context.Add(game);
        }
        public void update(WantsToPlay game)
        {
            context.Update(game);
        }

        public void Delete(string Name)
        {
            WantsToPlay game = GetByName(Name);
            context.Remove(game);
        }

        public List<WantsToPlay> GetAll()
        {
            return context.wantsToPlayGames.ToList();
        }

        public WantsToPlay GetByName(string Name)
        {
            return context.wantsToPlayGames.FirstOrDefault(x => x.Name == Name);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
