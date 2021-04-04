using DenikProject.DQEmulation.Model;
using DenikProject.DQEmulation.Presenter;
using DenikProject.DQEmulation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DenikProject.DQEmulation.LifetimeScopes
{
    public class DQEmulationLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private PlayerEntity _playerEntity = default;
        [SerializeField]
        private EnemyEntity _enemyEntity = default;
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
            builder.RegisterInstance(_enemyEntity);
            builder.RegisterInstance(_playerEntity);

            // Resource Provider
            builder.Register<EnemyResourceProvider>(Lifetime.Scoped);
            builder.Register<PlayerResourceProvider>(Lifetime.Scoped);

            // Model
            builder.RegisterInstance(_enemyModel).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(_playerModel).AsImplementedInterfaces().AsSelf();

            // View
            builder.RegisterInstance(_enemyView).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(_playerView).AsImplementedInterfaces().AsSelf();

            // Presenter (EntryPoint)
            builder.RegisterEntryPoint<DQEmulationPresenter>(Lifetime.Scoped);
        }
    }
}