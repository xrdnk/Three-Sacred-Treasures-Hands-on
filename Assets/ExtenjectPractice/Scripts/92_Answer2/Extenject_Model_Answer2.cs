using UniRx;

namespace Denik.ExtenjectPractice.Answer2
{
    public class Extenject_Model_Answer2
    {
        // 読み取り専用で ReactiveProperty を公開する（外部からの設定を防ぐことを保証する）
        public IReadOnlyReactiveProperty<int> Counter => _counterRp;
        // カプセル化を意識しよう．
        // NOTE : ReactiveProperty<int> でも良い．しかしシリアライズ化されないため，Inspector上で表示することが出来ない．
        private readonly IntReactiveProperty _counterRp = new IntReactiveProperty(0);

        /// <summary>
        /// カウンタをインクリメントする
        /// </summary>
        public void IncrementCount()
        {
            _counterRp.Value += 1;
        }
    }
}