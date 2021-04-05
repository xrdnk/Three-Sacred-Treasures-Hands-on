using DenikProject.DQEmulation.Entity;
using DenikProject.DQEmulation.Model;
using DenikProject.DQEmulation.Presenter;
using DenikProject.DQEmulation.Repository;
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
            builder.Register<EnemyRepository>(Lifetime.Scoped);
            builder.Register<PlayerRepository>(Lifetime.Scoped);

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