using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Sample.Game.Entities.Models;

namespace Sample.Game.Repository.Extensions
{
    public static class PlayerRepositoryExtensions
    {
        public static IQueryable<Player> SearchByAccount(this IQueryable<Player> players, string account)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                return players;
            }
            
            return players.Where(o => o.Account.ToLower().Contains(account.Trim().ToLower()));
        }
    }


}