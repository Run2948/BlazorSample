using System.Collections.Generic;

namespace Sample.Game.Entities.Dtos
{
    public class PlayerWithCharactersDto : PlayerDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; }
    }
}