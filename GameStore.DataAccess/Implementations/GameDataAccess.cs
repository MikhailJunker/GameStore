using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.DataAccess.Context;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Contracts;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DataAccess.Implementations
{
    public class GameDataAccess : IGameDataAccess
    {
        private GameStoreContext Context { get; }
        private IMapper Mapper { get; }

        public GameDataAccess(GameStoreContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }


        public async Task<Game> InsertAsync(GameUpdateModel game)
        {
            var result = await Context.Games.AddAsync(Mapper.Map<Entities.Game>(game));

            await Context.SaveChangesAsync();

            return Mapper.Map<Game>(result.Entity);
        }

        public async Task<IEnumerable<Game>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Game>>(await Context.Games.Include(x => x.Orders).ToListAsync());
        }

        public async Task<Game> GetAsync(IGameIdentity game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            return Mapper.Map<Game>(await Context.Games.Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == game.Id));
        }

        public async Task<Game> UpdateAsync(GameUpdateModel name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var entity = await Context.Games.FirstOrDefaultAsync(x => x.Id == name.Id);

            var result = Mapper.Map(name, entity);

            Context.Update(result);

            await Context.SaveChangesAsync();

            return Mapper.Map<Game>(result);
        }

        public async Task<Game> GetByAsync(IGameContainer container)
        {
            return Mapper.Map<Game>(await Context.Games.FirstOrDefaultAsync(x => x.Id == container.GameId));
        }
    }
}