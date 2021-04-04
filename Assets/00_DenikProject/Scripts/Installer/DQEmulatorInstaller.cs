using DenikProject.DQEmulation.Model;
using DenikProject.DQEmulation.View;
using UnityEngine;
using Zenject;

namespace DenikProject.DQEmulation.Installer
{
    public class DQEmulatorInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerModel _playerModel = default;
        [SerializeField]
        private EnemyModel _enemyModel = default;
        [SerializeField]
        private PlayerView _playerView = default;
        [SerializeField]
        private EnemyView _enemyView = default;

        public override void InstallBindings()
        {
            // Resource Provider
            Container.Bind<EnemyResourceProvider>().AsCached();
            Container.Bind<PlayerResourceProvider>().AsCached();

            // Model
            Container.BindInterfacesAndSelfTo<EnemyModel>().FromInstance(_enemyModel).AsCached();
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(_playerModel).AsCached();

            // View
            Container.BindInterfacesAndSelfTo<EnemyView>().FromInstance(_enemyView).AsCached();
            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView).AsCached();
        }
    }
}