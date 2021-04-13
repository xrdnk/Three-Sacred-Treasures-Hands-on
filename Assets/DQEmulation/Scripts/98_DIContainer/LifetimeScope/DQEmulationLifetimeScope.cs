using Denik.DQEmulation.Entity;
using Denik.DQEmulation.Model;
using Denik.DQEmulation.Presenter;
using Denik.DQEmulation.Repository;
using Denik.DQEmulation.Service;
using Denik.DQEmulation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Denik.DQEmulation.LifetimeScopes
{
    public class DQEmulationLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private PlayerData playerData = default;
        [SerializeField]
        private EnemyData enemyData = default;
        [SerializeField]
        private BGMData _bgmData = default;
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

        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.RegisterInstance(enemyData);
            builder.RegisterInstance(playerData);
            builder.RegisterInstance(_bgmData);

            // Repository
            builder.Register<EnemyRepository>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
            builder.Register<PlayerRepository>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
            builder.Register<BGMRepository>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();

            // Model
            builder.RegisterInstance(_enemyModel).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(_playerModel).AsImplementedInterfaces().AsSelf();

            // UseCase
            builder.RegisterInstance(_bgmPlayer).AsImplementedInterfaces().AsSelf();

            // View
            builder.RegisterComponent(_enemyView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_playerView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_playerSettingsView).AsSelf();

            // Presenter (EntryPoint)
            builder.RegisterEntryPoint<DQEmulationPresenter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<PlayerSettingsPresenter>(Lifetime.Scoped);
        }
    }
}