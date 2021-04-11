using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.UniRxPractice.Answer2
{
    public class Observable_Answer : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        // 発行している主題(Subject)自体は非公開にする
        private readonly Subject<Unit> _onHelloWorldTrigger = new Subject<Unit>();
        // IObservable（観測可能）だけ公開にする(カプセル化)
        public IObservable<Unit> OnHelloWorldAsObservable() => _onHelloWorldTrigger;

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
        }
    }
}