namespace Denik.DQEmulation.View
{
    public interface IDiedView
    {
        /// <summary>
        /// 倒されたことを購読する
        /// </summary>
        /// <param name="killedName">殺された相手の名前</param>
        void DisplayDied(string killedName);
    }
}