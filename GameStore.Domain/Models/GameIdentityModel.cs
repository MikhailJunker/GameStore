using System;
using System.Collections.Generic;
using System.Text;
using GameStore.Domain.Contracts;

namespace GameStore.Domain.Models
{
    public class GameIdentityModel : IGameIdentity
    {
        public int Id { get; }

        public GameIdentityModel(int id)
        {
            Id = id;
        }
    }
}
