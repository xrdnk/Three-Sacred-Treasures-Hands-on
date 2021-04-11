namespace Denik.DQEmulation.View
{
    public interface IDamagedView
    {
        /// <summary>
        /// ダメージを受けたことを購読する
        /// </summary>
        /// <param name="damagedPoint"></param>
        void DisplayDamaged(float damagedPoint);
    }
}