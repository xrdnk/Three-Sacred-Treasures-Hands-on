using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Denik.MessagePipePractice
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HelloWorldScreen _screen;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_screen);
            builder.Register<HelloWorldService>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MessagePipeDemo>();
        }
    }
}