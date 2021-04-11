using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.UniRxPractice.Answer1
{
    public class HelloWorld_Answer : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        // HelloWorldを表示するためのUnit型のSubjectを作成する
        public Subject<Unit> _onHelloWorldTrigger = new Subject<Unit>();

        private void Awake()
        {
            // ボタンを参照する
            _button
                // ボタンが押下された時を検知した時
                .OnClickAsObservable()
                // 購読し，HelloWorld表示イベントを発火
                .Subscribe(_ => _onHelloWorldTrigger.OnNext(Unit.Default))
                // Subscribe は IDisposable．
                // MonoBehaviour を継承している場合は .AddTo(this) を記述することで，
                // MonoBehaviour クラスが破棄された時，このSubscribeも自動的に破棄できる．
                .AddTo(this);


            // OnHelloWorldTrigger が発火された時
            _onHelloWorldTrigger
                // 購読し，Debug.Log で表示する
                // Unit型なので，引数は _ (discard:ディスカードと呼ぶ) にする
                .Subscribe(_ => Debug.Log("Hello World!"))
                // Subscribe は IDisposable．
                // MonoBehaviour を継承している場合は .AddTo(this) を記述することで，
                // MonoBehaviour クラスが破棄された時，このSubscribeも自動的に破棄できる．
                .AddTo(this);
        }
    }
}