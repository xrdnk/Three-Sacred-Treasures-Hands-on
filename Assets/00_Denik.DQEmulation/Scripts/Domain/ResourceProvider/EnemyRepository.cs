using DenikProject.DQEmulation.Entity;

namespace DenikProject.DQEmulation.Repository
{
    public class EnemyRepository
    {
        public EnemyEntity EnemyEntity => _enemyEntity;
        private EnemyEntity _enemyEntity;

        [Zenject.Inject]
        [VContainer.Inject]
        private EnemyRepository(EnemyEntity enemyEntity)
        {
            _enemyEntity = enemyEntity;
        }
    }
}