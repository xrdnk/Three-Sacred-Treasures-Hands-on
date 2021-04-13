namespace Denik.DQEmulation.View
{
    public interface IDamagedView
    {
        /// <summary>
        /// HPを表示する
        /// </summary>
        /// <param name="hp"></param>
        void DisplayHp(float hp);
        /// <summary>
        /// ダメージを受けたことを購読する
        /// </summary>
        /// <param name="damagedPoint"></param>
        void DisplayDamaged(float damagedPoint);
    }
}