using System.Collections.Generic;
using IndieGamesRepositoryAPP.Interfaces;

namespace IndieGamesRepositoryAPP.Classes
{
    public class GamesRepository : IRepository<Games>
    {
        private List<Games> _gamesList = new List<Games>();

        public List<Games> List()
        {
            return _gamesList;
        }

        public Games ReadById(int id)
        {
            return _gamesList[id];
        }

        public void Create(Games game)
        {
            _gamesList.Add(game);
        }

        public void Update(int id, Games game)
        {
            _gamesList[id] = game;
        }

        public void Delete(int id)
        {
            _gamesList[id].Delete();
        }

        public int NextId()
        {
            return _gamesList.Count;
        }
    }
}