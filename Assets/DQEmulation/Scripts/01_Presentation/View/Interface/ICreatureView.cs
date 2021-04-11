using UnityEngine;

namespace Denik.DQEmulation.View
{
    public interface ICreatureView
    {
        /// <summary>
        /// 名前を表示する
        /// </summary>
        /// <param name="name"></param>
        void DisplayName(string name);
        /// <summary>
        /// 姿を表示する（ここでは Sprite とする）
        /// </summary>
        /// <param name="figure"></param>
        void DisplayFigure(Sprite figure);
        /// <summary>
        /// HPを表示する
        /// </summary>
        /// <param name="hp"></param>
        void DisplayHp(float hp);
    }
}