using UniRx;
using UnityEngine;

namespace Denik.UniRxPractice.Answer2
{
    public class Observer_Answer : MonoBehaviour
    {
        [SerializeField]
        private Observable_Answer _observable;

        private void Awake()
        {
            // Observableを参照する
            _observable
                // OnHelloWorldAsObservable.OnNext が発火された時
                .OnHelloWorldAsObservable()
                // 購読して，Debug.Log で表示する
                // Unit型なので，引数は _ (discard:ディスカードと呼ぶ) にする
                .Subscribe(_ => Debug.Log("Hello World!"))
                // Subscribe は IDisposable．
                // MonoBehaviour を継承している場合は .AddTo(this) を記述することで，
                // MonoBehaviour クラスが破棄された時，このSubscribeも自動的に破棄できる．
                .AddTo(this);
        }
    }
}