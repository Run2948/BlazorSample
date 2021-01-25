using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.Game.Contracts;
using Sample.Game.Entities.Dtos;
using Sample.Game.Entities.Models;
using Sample.Game.Entities.RequestFeatures;
using Sample.Game.Entities.ResponseType.DataShaping;
using Sample.Game.HttpApi.Extensions;

namespace Sample.Game.HttpApi.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IRepositoryWrapper repository, 
            ILogger<PlayerController> logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlayers([FromQuery] PlayerParameter parameter)
        {
            try
            {
                if (!parameter.ValidDateCreatedRange)
                {
                    return BadRequest("结束日期需要小于开始日期不");
                }

                var players = _repository.Player.GetPlayers(parameter);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(players.MetaData));

                var result = _mapper.Map<IEnumerable<PlayerDto>>(players)
                    .ShapeData(parameter.Fields);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "PlayerById")]
        public IActionResult GetPlayerById(Guid id, [FromQuery] string fields)
        {
            try
            {
                var player = _repository.Player.GetPlayerById(id);
                if (player is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerDto>(player)
                    .ShapeData(fields); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/character")]
        public IActionResult GetPlayerWithCharacters(Guid id)
        {
            try
            {
                var player = _repository.Player.GetPlayerWithCharacters(id);

                if (player is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerWithCharactersDto>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody]PlayerForCreationDto player)
        {
            try
            {
                if (player is null)
                {
                    return BadRequest("Player 不能为 Null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求对象");
                }

                var playerEntity = _mapper.Map<Player>(player);

                _repository.Player.CreatePlayer(playerEntity);
                _repository.Save();

                var createdPlayer = _mapper.Map<PlayerDto>(playerEntity);

                return CreatedAtRoute("PlayerById", new { id = createdPlayer.Id }, createdPlayer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(Guid id, [FromBody]PlayerForUpdateDto player)
        {
            try
            {
                if (player is null)
                {
                    return BadRequest("Player 不能为 Null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求对象");
                }

                var playerEntity = _repository.Player.GetPlayerById(id);
                if (playerEntity is null)
                {
                    return NotFound("待修改的玩家不存在");
                }

                _mapper.Map(player, playerEntity);

                _repository.Player.UpdatePlayer(playerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            try
            {
                var player = _repository.Player.GetPlayerWithCharacters(id);
                if (player is null)
                {
                    return BadRequest("待删除的玩家不存在");
                }

                if (player.Characters.Any())
                {
                    return BadRequest("该玩家有关联人物角色，不能删除！");
                }

                _repository.Player.DeletePlayer(player);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
