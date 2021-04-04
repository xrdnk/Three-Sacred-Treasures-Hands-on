using Zenject;

namespace DenikProject.DQEmulation.Model
{
    public class EnemyResourceProvider
    {
        public EnemyEntity EnemyEntity => _enemyEntity;
        private EnemyEntity _enemyEntity;

        [Inject]
        private EnemyResourceProvider(EnemyEntity enemyEntity)
        {
            _enemyEntity = enemyEntity;
        }
    }
}