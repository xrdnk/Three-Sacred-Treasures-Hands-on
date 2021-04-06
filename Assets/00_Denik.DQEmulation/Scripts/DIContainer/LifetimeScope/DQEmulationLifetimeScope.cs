using Denik.DQEmulation.Entity;
using Denik.DQEmulation.Model;
using Denik.DQEmulation.Presenter;
using Denik.DQEmulation.Repository;
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
        private PlayerModel _playerModel = default;
        [SerializeField]
        private EnemyModel _enemyModel = default;
        [SerializeField]
        private PlayerView _playerView = default;
        [SerializeField]
        private EnemyView _enemyView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.RegisterInstance(enemyData);
            builder.RegisterInstance(playerData);

            // Resource Provider
            builder.Register<EnemyResourceProvider>(Lifetime.Scoped);
            builder.Register<PlayerResourceProvider>(Lifetime.Scoped);

            // Model
            builder.RegisterComponent(_enemyModel).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_playerModel).AsImplementedInterfaces().AsSelf();

            // View
            builder.RegisterComponent(_enemyView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_playerView).AsImplementedInterfaces().AsSelf();

            // Presenter (EntryPoint)
            builder.RegisterEntryPoint<DQEmulationPresenter>(Lifetime.Scoped);
        }
    }
}