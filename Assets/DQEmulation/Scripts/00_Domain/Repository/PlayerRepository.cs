using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private PlayerData _playerData;

        [Zenject.Inject]
        [VContainer.Inject]
        private PlayerRepository(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public List<PlayerEntity> PlayerEntities => _playerData.PlayerEntities;

        public PlayerEntity GetPlayerEntity(int index) => _playerData.PlayerEntities[index];
    }
}