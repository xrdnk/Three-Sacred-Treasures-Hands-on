using Denik.ExtenjectPractice.Question2;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SampleLifetimeScope : LifetimeScope
{
    [SerializeField] private Extenject_View_Question2 _view;

    protected override void Configure(IContainerBuilder builder)
    {
        // Model の Bind を行う
        builder.Register<Extenject_Model_Question2>(Lifetime.Scoped);
        // View の Bind を行う
        builder.RegisterInstance(_view);
        builder.RegisterEntryPoint<Extenject_Presenter_Question2>(Lifetime.Scoped);
    }
}