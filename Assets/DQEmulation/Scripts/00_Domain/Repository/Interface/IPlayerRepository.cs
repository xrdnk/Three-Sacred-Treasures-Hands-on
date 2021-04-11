using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public interface IPlayerRepository
    {
        List<PlayerEntity> PlayerEntities { get; }
        PlayerEntity GetPlayerEntity(int index);
    }
}