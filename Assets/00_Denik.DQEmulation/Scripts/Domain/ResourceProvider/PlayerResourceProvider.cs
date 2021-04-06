using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class PlayerResourceProvider
    {
        public PlayerData PlayerData => _playerData;
        private PlayerData _playerData;

        [Zenject.Inject]
        [VContainer.Inject]
        private PlayerResourceProvider(PlayerData playerData)
        {
            _playerData = playerData;
        }
    }
}