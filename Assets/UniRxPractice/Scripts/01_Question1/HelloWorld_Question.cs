using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.UniRxPractice.Question1
{
    public class HelloWorld_Question : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        // HelloWorldを表示するためのUnit型のSubjectを作成する
        // 今回，「ボタンを押した」というイベントさえ通知すればよいので，Unit型にする
        public Subject<Unit> _onHelloWorldTrigger = new Subject<Unit>();

        private void Awake()
        {
            // ボタンを参照する
            _button
                // ボタンが押下された時を検知した時
                .OnClickAsObservable()
                // 購読し，HelloWorld表示イベントを発火
                .Subscribe(_ => _onHelloWorldTrigger.OnNext(Unit.Default))
                .AddTo(this);

            // OnHelloWorldTrigger が発火された時
            _onHelloWorldTrigger
                // 購読し，Debug.Log で表示する
                .Subscribe(_ => Debug.Log("Hello World!"))
                .AddTo(this);
        }
    }
}