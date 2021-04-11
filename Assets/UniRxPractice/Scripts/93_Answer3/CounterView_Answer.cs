using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.UniRxPractice.Answer3
{
    public class CounterView_Answer : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Text _textCounter;
        [SerializeField]
        private CounterModel_Answer _model;

        public IObservable<Unit> OnCountAsObservable() => _onCountTrigger;
        private readonly Subject<Unit> _onCountTrigger = new Subject<Unit>();

        private void Awake()
        {
            // Buttonを参照する
            _button
                // ボタンが押下された時
                .OnClickAsObservable()
                // 購読し，カウンタを実行するイベントを発行する
                .Subscribe(_ => _onCountTrigger.OnNext(Unit.Default))
                .AddTo(this);

            // Modelを参照する
            _model
                // ReactivePropertyであるCounterの値が変化した時
                .Counter
                // 購読し，値の変化をDisplayCounterで表示する
                .Subscribe(count => DisplayCounter(count))
                // 1引数1メソッドが保証されている時，以下のようにMethod Groupで短縮形にすることが出来る
                // .Subscribe(DisplayCounter)
                .AddTo(this);
        }

        /// <summary>
        /// カウンタ表示用のメソッド
        /// </summary>
        /// <param name="count"></param>
        private void DisplayCounter(int count)
        {
            _textCounter.text = $"Counter: {count}";
        }
    }
}