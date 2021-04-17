using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Denik.VContainerPractice.Answer1
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HelloWorldScreen _screen;
        protected override void Configure(IContainerBuilder builder)
        {
            // Hierarchy 上に実体があるので，RegisterInstance
            builder.RegisterInstance(_screen);
            // Plain C# Class なので，Register
            builder.Register<HelloWorldService>(Lifetime.Scoped);
            // IStartable を実装しているので，RegisterEntryPoint
            builder.RegisterEntryPoint<GamePresenter>();
        }
    }
}