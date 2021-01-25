using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Sample.Game.Entities.Dtos;

namespace Sample.Game.Blazor.Components
{
    public partial class PlayerTable
    {
        [Parameter]
        public List<PlayerDto> Players { get; set; }
    }
}