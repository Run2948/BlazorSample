using System.Threading.Tasks;
using Sample.Game.Blazor.Features;
using Sample.Game.Entities.Dtos;
using Sample.Game.Entities.RequestFeatures;

namespace Sample.Game.Blazor.HttpRepository
{
    public interface IPlayerHttpRepository
    {
        Task<PagingResponse<PlayerDto>> GetPlayers(PlayerParameter playerParameters);
    }
}