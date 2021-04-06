using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class EnemyResourceProvider
    {
        public EnemyData EnemyData => _enemyData;
        private EnemyData _enemyData;

        [Zenject.Inject]
        [VContainer.Inject]
        private EnemyResourceProvider(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }
    }
}