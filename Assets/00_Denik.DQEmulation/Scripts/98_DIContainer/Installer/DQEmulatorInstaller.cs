using Denik.DQEmulation.Model;
using Denik.DQEmulation.Presenter;
using Denik.DQEmulation.Repository;
using Denik.DQEmulation.Service;
using Denik.DQEmulation.View;
using UnityEngine;
using Zenject;

namespace Denik.DQEmulation.Installer
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
        [SerializeField]
        private BGMPlayer _bgmPlayer = default;
        [SerializeField]
        private PlayerSettingsView _playerSettingsView = default;

        public override void InstallBindings()
        {
            // Resource Provider
            Container.BindInterfacesAndSelfTo(typeof(EnemyRepository)).AsCached();
            Container.BindInterfacesAndSelfTo(typeof(PlayerRepository)).AsCached();
            Container.BindInterfacesAndSelfTo(typeof(BGMRepository)).AsCached();

            // Model
            Container.BindInterfacesAndSelfTo(typeof(EnemyModel)).FromInstance(_enemyModel).AsCached();
            Container.BindInterfacesAndSelfTo(typeof(PlayerModel)).FromInstance(_playerModel).AsCached();

            // View
            Container.BindInterfacesAndSelfTo(typeof(EnemyView)).FromInstance(_enemyView).AsCached();
            Container.BindInterfacesAndSelfTo(typeof(PlayerView)).FromInstance(_playerView).AsCached();
            Container.Bind(typeof(PlayerSettingsView)).FromInstance(_playerSettingsView).AsCached();

            // Service
            Container.BindInterfacesAndSelfTo(typeof(BGMPlayer)).FromInstance(_bgmPlayer).AsCached();

            // Presenter
            Container.Bind(typeof(DQEmulationPresenter), typeof(IInitializable))
                .To(typeof(DQEmulationPresenter))
                .AsCached();
            Container.Bind(typeof(PlayerSettingsPresenter), typeof(IInitializable))
                .To(typeof(PlayerSettingsPresenter))
                .AsCached();
        }
    }
}