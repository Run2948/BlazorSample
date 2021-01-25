namespace Sample.Game.Contracts
{
    public interface IRepositoryWrapper
    {
        IPlayerRepository Player { get; }
        ICharacterRepository Character { get; }
        void Save();
    }
}