using Zenject;

namespace DenikProject.DQEmulation.Model
{
    public class PlayerResourceProvider
    {
        public PlayerEntity PlayerEntity => _playerEntity;
        private PlayerEntity _playerEntity;

        [Inject]
        private PlayerResourceProvider(PlayerEntity playerEntity)
        {
            _playerEntity = playerEntity;
        }
    }
}