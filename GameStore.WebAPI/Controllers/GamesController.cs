using AutoMapper;
using GameStore.BLL.Contracts;
using GameStore.Client.DTO;
using GameStore.Client.Requests.Create;
using GameStore.Client.Requests.Update;
using GameStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.WebAPI.Controllers
{
    [Route("games")]
    public class GamesController : Controller
    {

        private ILogger<GamesController> Logger { get; }
        private IGameCreateService GamesCreateService { get; }
        private IGameGetService GamesGetService { get; }
        private IGameUpdateService GamesUpdateService { get; }
        private IMapper Mapper { get; }

        public GamesController(ILogger<GamesController> logger, IGameCreateService gameCreateService, IGameGetService gameGetService, IGameUpdateService gameUpdateService, IMapper mapper)
        {
            Logger = logger;
            GamesCreateService = gameCreateService;
            GamesGetService = gameGetService;
            GamesUpdateService = gameUpdateService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IActionResult> Index()
        {
            var list = Mapper.Map<IEnumerable<GameDTO>>(await GamesGetService.GetAsync());

            return View(list);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var game = Mapper.Map<GameDTO>(await GamesGetService.GetAsync(new GameIdentityModel((int)id)));

            if (game is null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpGet]
        [Route("new")]
        public ActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new")]
        public async Task<IActionResult> Create(GameCreateDTO gameCreate)
        {
            var game = Mapper.Map<GameDTO>(
                await GamesCreateService.CreateAsync(Mapper.Map<GameUpdateModel>(gameCreate)));
            return Redirect($"/games/{game.Id}");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var game = Mapper.Map<GameDTO>(await GamesGetService.GetAsync(new GameIdentityModel((int)id)));
            if (game is null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, GameUpdateDTO updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return NotFound();
            }

            var game =
                Mapper.Map<GameDTO>(await GamesUpdateService.UpdateAsync(Mapper.Map<GameUpdateModel>(updatedGame)));
            return Redirect($"/games/{game.Id}");

        }

    }
}
