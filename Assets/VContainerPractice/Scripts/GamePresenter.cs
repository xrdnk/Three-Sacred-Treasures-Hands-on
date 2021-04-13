using UnityEngine;
using VContainer.Unity;

namespace MyGame
{
    public class GamePresenter : IStartable
    {
        readonly HelloWorldService helloWorldService;

        public GamePresenter(
            HelloWorldService helloWorldService)
        {
            Debug.Log("test");
            this.helloWorldService = helloWorldService;
        }

        void IStartable.Start()
        {
            helloWorldService.Hello();
        }
    }
}