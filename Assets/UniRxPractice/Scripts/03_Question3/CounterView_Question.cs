using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.UniRxPractice.Question3
{
    public class CounterView_Question : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Text _textCounter;
        [SerializeField]
        private CounterModel_Question _model;

        public IObservable<Unit> OnCountAsObservable() => _onCountTrigger;
        private readonly Subject<Unit> _onCountTrigger = new Subject<Unit>();

        private void Awake()
        {
            // Buttonを参照する

                // ボタンが押下された時

                // 購読し，カウンタを実行するイベントを発行する

            // Modelを参照する

                // ReactivePropertyであるCounterの値が変化した時

                // 購読し，値の変化をDisplayCounterで表示する


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