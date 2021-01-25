using System;
using Sample.Game.Entities.Models;

namespace Sample.Game.Entities
{
    public static class DataSeed
    {
        private static readonly Guid[] _guids =
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };


        public static Player[] Players { get; } = {
            new Player
            {
                Id = _guids[0],
                Account = "mw2021",
                AccountType = "Free",
                DateCreated = DateTime.Now
            },
            new Player
            {
                Id = _guids[1],
                Account = "dc2021",
                AccountType = "Free",
                DateCreated = DateTime.Now
            }
        };

        public static Character[] Characters { get; } =
        {
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Code Man",
                Classes = "Mage",
                Level = 99,
                PlayerId = _guids[0],
                DateCreated = DateTime.Now
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Iron Man",
                Classes = "Warrior",
                Level = 90,
                PlayerId = _guids[0],
                DateCreated = DateTime.Now
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Spider Man",
                Classes = "Druid",
                Level = 80,
                PlayerId = _guids[0],
                DateCreated = DateTime.Now
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Batman",
                Classes = "Death Knight",
                Level = 90,
                PlayerId = _guids[1],
                DateCreated = DateTime.Now
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Superman",
                Classes = "Paladin",
                Level = 99,
                PlayerId = _guids[1],
                DateCreated = DateTime.Now
            }
        };
    }
}
