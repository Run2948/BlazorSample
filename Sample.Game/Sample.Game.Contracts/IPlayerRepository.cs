using System;
using System.Collections.Generic;
using System.Text;
using Sample.Game.Entities.Models;
using Sample.Game.Entities.RequestFeatures;
using Sample.Game.Entities.ResponseType;
using Sample.Game.Entities.ResponseType.Paging;

namespace Sample.Game.Contracts
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        PagedList<Player> GetPlayers(PlayerParameter parameter);
        Player GetPlayerById(Guid playerId);
        Player GetPlayerWithCharacters(Guid playerId);
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
