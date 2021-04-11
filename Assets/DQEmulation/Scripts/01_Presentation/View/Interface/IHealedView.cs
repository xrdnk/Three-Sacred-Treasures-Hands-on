namespace Denik.DQEmulation.View
{
    public interface IHealedView
    {
        /// <summary>
        /// 回復されたことを購読する
        /// </summary>
        /// <param name="healedPoint"></param>
        void DisplayHealed(float healedPoint);
    }
}