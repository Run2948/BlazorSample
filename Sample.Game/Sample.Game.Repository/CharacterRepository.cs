using System;
using System.Collections.Generic;
using System.Linq;
using Sample.Game.Contracts;
using Sample.Game.Entities;
using Sample.Game.Entities.Models;

namespace Sample.Game.Repository
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(GameDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}