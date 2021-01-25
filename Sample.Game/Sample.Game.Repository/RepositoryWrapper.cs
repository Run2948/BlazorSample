using Sample.Game.Contracts;
using Sample.Game.Entities;

namespace Sample.Game.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GameDbContext _gameDbContext;
        private IPlayerRepository _player;
        private ICharacterRepository _character;

        public IPlayerRepository Player {
            get { return _player ??= new PlayerRepository(_gameDbContext); }
        }

        public ICharacterRepository Character {
            get { return _character ??= new CharacterRepository(_gameDbContext); }
        }

        public RepositoryWrapper(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public void Save()
        {
            _gameDbContext.SaveChanges();
        }
    }
}