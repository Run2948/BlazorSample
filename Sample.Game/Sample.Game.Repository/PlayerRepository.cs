using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sample.Game.Contracts;
using Sample.Game.Entities;
using Sample.Game.Entities.Models;
using Sample.Game.Entities.RequestFeatures;
using Sample.Game.Entities.ResponseType;
using Sample.Game.Entities.ResponseType.Paging;
using Sample.Game.Repository.Extensions;

namespace Sample.Game.Repository
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(GameDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public PagedList<Player> GetPlayers(PlayerParameter parameter)
        {
            return FindByCondition(player => player.DateCreated.Date >= parameter.MinDateCreated.Date 
                                             && player.DateCreated.Date <= parameter.MaxDateCreated.Date)
                .SearchByAccount(parameter.Account)
                .OrderByQuery(parameter.OrderBy)
                .ToPagedList(parameter.PageNumber, parameter.PageSize);
        }


        public Player GetPlayerById(Guid playerId)
        {
            return FindByCondition(player => player.Id == playerId)
                .FirstOrDefault();
        }

        public Player GetPlayerWithCharacters(Guid playerId)
        {
            return FindByCondition(player => player.Id == playerId)
                .Include(player => player.Characters)
                .FirstOrDefault();
        }

        public void CreatePlayer(Player player)
        {
            Create(player);
        }

        public void UpdatePlayer(Player player)
        {
            Update(player);
        }

        public void DeletePlayer(Player player)
        {
            Delete(player);
        }
    }
}