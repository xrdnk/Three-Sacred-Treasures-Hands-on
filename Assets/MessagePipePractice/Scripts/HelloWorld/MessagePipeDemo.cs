using System;
using VContainer.Unity;
using UniRx;
using VContainer;

namespace Denik.MessagePipePractice
{
    public class MessagePipeDemo : IStartable, IDisposable
    {
        private readonly HelloWorldService _helloWorldService;
        private readonly HelloWorldScreen _helloWorldScreen;

        [Inject]
        public MessagePipeDemo(HelloWorldService helloWorldService, HelloWorldScreen helloWorldScreen)
        {
            _helloWorldService = helloWorldService;
            _helloWorldScreen = helloWorldScreen;
        }

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

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