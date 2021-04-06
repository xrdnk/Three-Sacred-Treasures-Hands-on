using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class PlayerResourceProvider
    {
        public PlayerEntity PlayerEntity => _playerEntity;
        private PlayerEntity _playerEntity;

        [Zenject.Inject]
        [VContainer.Inject]
        private PlayerResourceProvider(PlayerEntity playerEntity)
        {
            _playerEntity = playerEntity;
        }
    }
}