using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class EnemyResourceProvider
    {
        public EnemyEntity EnemyEntity => _enemyEntity;
        private EnemyEntity _enemyEntity;

        [Zenject.Inject]
        [VContainer.Inject]
        private EnemyResourceProvider(EnemyEntity enemyEntity)
        {
            _enemyEntity = enemyEntity;
        }
    }
}