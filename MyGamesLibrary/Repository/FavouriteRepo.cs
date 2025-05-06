using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public class FavouriteRepo : IFavouriteRepo
    {
        AppDbContext context;
        public FavouriteRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Favourite game)
        {
            context.Add(game);
        }
        public void update(Favourite game)
        {
            context.Update(game);
        }

        public void Delete(string Name)
        {
            Favourite game = GetByName(Name);
            context.Remove(game);
        }

        public List<Favourite> GetAll()
        {
            return context.FavGames.ToList();
        }

        public Favourite GetByName(string Name)
        {
            return context.FavGames.FirstOrDefault(x => x.Name == Name);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Check(Favourite game)
        {
            return context.FavGames.Contains(game);
        }
    }
}
