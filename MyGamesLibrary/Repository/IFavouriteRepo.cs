using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public interface IFavouriteRepo
    {
        public void Add(Favourite game);
        public void update(Favourite game);
        public void Delete(string Name);
        public List<Favourite> GetAll();
        public Favourite GetByName(string Name);
        public bool Check(Favourite game);
        public void Save();
    }
}
