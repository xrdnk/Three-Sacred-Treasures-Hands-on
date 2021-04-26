namespace Denik.DQEmulation.View
{
    public interface IHealedView
    {
        /// <summary>
        /// MPを表示する
        /// </summary>
        /// <param name="mp"></param>
        void DisplayMp(float mp);
        /// <summary>
        /// 回復されたことを購読する
        /// </summary>
        /// <param name="healedPoint"></param>
        void DisplayHealed(float healedPoint);
    }
}