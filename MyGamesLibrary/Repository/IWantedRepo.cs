using MyGamesLibrary.Models;

namespace MyGamesLibrary.Repository
{
    public interface IWantedRepo
    {
        public void Add(WantsToPlay game);
        public void update(WantsToPlay game);
        public void Delete(string Name);
        public List<WantsToPlay> GetAll();
        public WantsToPlay GetByName(string Name);
        public void Save();
    }
}
