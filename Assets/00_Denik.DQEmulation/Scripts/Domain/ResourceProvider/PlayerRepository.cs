using DenikProject.DQEmulation.Entity;

namespace DenikProject.DQEmulation.Repository
{
    public class PlayerRepository
    {
        public PlayerEntity PlayerEntity => _playerEntity;
        private PlayerEntity _playerEntity;

        [Zenject.Inject]
        [VContainer.Inject]
        private PlayerRepository(PlayerEntity playerEntity)
        {
            _playerEntity = playerEntity;
        }
    }
}