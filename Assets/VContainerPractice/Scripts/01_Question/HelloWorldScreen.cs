using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.VContainerPractice.Question1
{
    public class HelloWorldScreen : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        public IObservable<Unit> OnButtonPushedAsObservable() => _onButtonPushedSubject;
        private readonly Subject<Unit> _onButtonPushedSubject = new Subject<Unit>();

        private void Awake()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => _onButtonPushedSubject.OnNext(Unit.Default))
                .AddTo(this);
        }
    }
}