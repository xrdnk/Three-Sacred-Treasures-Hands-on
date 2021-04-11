using UniRx;
using UnityEngine;

namespace Denik.UniRxPractice.Question3
{
    public class CounterModel_Question : MonoBehaviour
    {
        [SerializeField]
        private CounterView_Question _view;

        // 読み取り専用で ReactiveProperty を公開する（外部からの設定を防ぐことを保証する）
        public IReadOnlyReactiveProperty<int> Counter => _counterRp;
        // カプセル化を意識しよう．
        // NOTE : ReactiveProperty<int> でも良い．しかしシリアライズ化されないため，Inspector上で表示することが出来ない．
        private readonly IntReactiveProperty _counterRp = new IntReactiveProperty(0);

        private void Awake()
        {
            // Viewを参照する

                // ViewからCountイベントの発火が通知された時

                // 発行し，カウンタのインクリメント処理を実行する

        }

        /// <summary>
        /// カウンタをインクリメントする
        /// </summary>
        private void IncrementCount()
        {
            _counterRp.Value += 1;
        }
    }
}