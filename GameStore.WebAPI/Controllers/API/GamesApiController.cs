using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.Contracts;
using GameStore.Client.DTO;
using GameStore.Client.Requests.Create;
using GameStore.Client.Requests.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.DataAccess.Context;
using GameStore.DataAccess.Entities;
using GameStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesApiController : Controller
    {
        private ILogger<GamesApiController> Logger { get; }
        private IGameCreateService GameCreateService { get; }
        private IGameGetService GameGetService { get; }
        private IGameUpdateService GameUpdateService { get; }
        private IMapper Mapper { get; }

        public GamesApiController(ILogger<GamesApiController> logger, IGameCreateService gameCreateService, IGameGetService gameGetService, IGameUpdateService gameUpdateService, IMapper mapper)
        {
            Logger = logger;
            GameCreateService = gameCreateService;
            GameGetService = gameGetService;
            GameUpdateService = gameUpdateService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IEnumerable<GameDTO>> GetAll()
        {
            return Mapper.Map<IEnumerable<GameDTO>>(await GameGetService.GetAsync());
        }


        [HttpGet]
        [Route("{gameId}")]
        [Route("get/{gameId}")]
        public async Task<GameDTO> Get(int gameId)
        {
            return Mapper.Map<GameDTO>(await GameGetService.GetAsync(new GameIdentityModel(gameId)));
        }

        [HttpPost]
        [Route("create")]
        [Route("new")]
        public async Task<GameDTO> Create(GameCreateDTO game)
        {
            var result = await GameCreateService.CreateAsync(Mapper.Map<GameUpdateModel>(game));

            return Mapper.Map<GameDTO>(result);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<GameDTO> Edit(GameUpdateDTO game)
        {
            var result = await GameUpdateService.UpdateAsync(Mapper.Map<GameUpdateModel>(game));

            return Mapper.Map<GameDTO>(result);
        }
    }
}
