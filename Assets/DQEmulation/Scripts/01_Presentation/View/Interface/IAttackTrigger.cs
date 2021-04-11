using System;
using UniRx;

namespace Denik.DQEmulation.View
{
    public interface IAttackTrigger
    {
        /// <summary>
        /// 攻撃することを通知する
        /// </summary>
        /// <returns>攻撃者</returns>
        IObservable<string> OnAttackTriggerAsObservable();
    }
}