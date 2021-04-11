using System;

namespace Denik.DQEmulation.View
{
    public interface IHealTrigger
    {
        /// <summary>
        /// 回復させることを通知する
        /// </summary>
        /// <returns>回復魔法を唱えた者</returns>
        IObservable<string> OnHealTriggerAsObservable();
    }
}