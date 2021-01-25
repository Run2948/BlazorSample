using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Sample.Game.Blazor.HttpRepository;
using Sample.Game.Entities.Dtos;
using Sample.Game.Entities.RequestFeatures;
using Sample.Game.Entities.ResponseType.Paging;

namespace Sample.Game.Blazor.Pages
{
    public partial class Players
    {
        public List<PlayerDto> PlayerList { get; set; } = new List<PlayerDto>();
        public PagedMetaData MetaData { get; set; } = new PagedMetaData();
        private readonly PlayerParameter _PlayerParameter = new PlayerParameter();

        [Inject]
        public IPlayerHttpRepository PlayerRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var pagingResponse = await PlayerRepo.GetPlayers(_PlayerParameter);
            PlayerList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
    }
}
