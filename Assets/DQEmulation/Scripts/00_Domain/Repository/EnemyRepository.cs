using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class EnemyRepository : IEnemyRepository
    {
        private EnemyData _enemyData;

        [Zenject.Inject]
        [VContainer.Inject]
        private EnemyRepository(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public List<EnemyEntity> EnemyEntities => _enemyData.EnemyEntities;

        public EnemyEntity GetEnemyEntity(int index)
        {
            return _enemyData.EnemyEntities[index];
        }
    }
}