using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public interface IPlayedRepo
    {
        public void Add(Played game);
        public void update(Played game);
        public void Delete(string Name);
        public List<Played> GetAll();
        public Played GetByName(string Name);
        public void Save();

    }
}
