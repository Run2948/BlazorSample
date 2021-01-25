using System;

namespace Sample.Game.Entities.Dtos
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Classes { get; set; }
        public int Level { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
