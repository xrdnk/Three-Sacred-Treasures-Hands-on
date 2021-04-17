using System;
using VContainer.Unity;
using UniRx;

namespace Denik.VContainerPractice.Question1
{
    public class GamePresenter : IStartable, IDisposable
    {
        private readonly HelloWorldService _helloWorldService;
        private readonly HelloWorldScreen _helloWorldScreen;

        // 一応Injectを書かなくてもよい
        // [Inject]
        public GamePresenter(HelloWorldService helloWorldService, HelloWorldScreen helloWorldScreen)
        {
            _helloWorldService = helloWorldService;
            _helloWorldScreen = helloWorldScreen;
        }

        // Plain C# Class の場合は AddTo(this); はできないため， CompositeDispposable で Dispose する
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        // MonoBehaviour を継承してないので，
        // VContainer.Unity.IStartable を実装することで，
        // 疑似的に Start() を呼び出す
        void IStartable.Start()
        {
            _helloWorldScreen.OnButtonPushedAsObservable()
                .Subscribe(_ => _helloWorldService.Hello())
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}