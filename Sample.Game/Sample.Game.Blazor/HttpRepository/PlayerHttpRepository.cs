using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Sample.Game.Blazor.Features;
using Sample.Game.Entities.Dtos;
using Sample.Game.Entities.RequestFeatures;
using Sample.Game.Entities.ResponseType.Paging;

namespace Sample.Game.Blazor.HttpRepository
{
    public class PlayerHttpRepository : IPlayerHttpRepository
    {
        private readonly HttpClient _client;
        public PlayerHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<PagingResponse<PlayerDto>> GetPlayers(PlayerParameter playerParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = playerParameters.PageNumber.ToString()
            };

            var response = await _client.GetAsync(QueryHelpers.AddQueryString("/api/player", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            
            var pagingResponse = new PagingResponse<PlayerDto>
            {
                Items = JsonSerializer.Deserialize<List<PlayerDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                MetaData = JsonSerializer.Deserialize<PagedMetaData>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true})
            };

            return pagingResponse;
        }
    }
}