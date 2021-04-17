using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Denik.VContainerPractice.Question1
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HelloWorldScreen _screen;
        protected override void Configure(IContainerBuilder builder)
        {
            // Hierarchy 上に実体があるので，RegisterInstance

            // Plain C# Class なので，Register

            // IStartable を実装しているので，RegisterEntryPoint

        }
    }
}