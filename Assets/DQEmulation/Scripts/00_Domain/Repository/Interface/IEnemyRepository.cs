using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public interface IEnemyRepository
    {
        List<EnemyEntity> EnemyEntities { get; }
        EnemyEntity GetEnemyEntity(int index);
    }
}