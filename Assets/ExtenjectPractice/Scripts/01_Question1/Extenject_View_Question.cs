using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.ExtenjectPractice.Question1
{
    public class Extenject_View_Question : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Text _textCounter;

        public IObservable<Unit> OnCountAsObservable() => _onCountTrigger;
        private readonly Subject<Unit> _onCountTrigger = new Subject<Unit>();

        private void Awake()
        {
            // Buttonを参照する

                // ボタンが押下された時

                // 購読し，カウンタを実行するイベントを発行する

        }

        /// <summary>
        /// カウンタ表示用のメソッド
        /// </summary>
        /// <param name="count"></param>
        public void DisplayCounter(int count)
        {
            _textCounter.text = $"Counter: {count}";
        }
    }
}