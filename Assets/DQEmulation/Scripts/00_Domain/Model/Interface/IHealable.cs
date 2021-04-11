using System;

namespace Denik.DQEmulation.Model
{
    public interface IHealable
    {
        /// <summary>
        /// 回復力
        /// </summary>
        float HealPower { get; }
        /// <summary>
        /// 回復されたことを通知する
        /// </summary>
        /// <returns>回復量</returns>
        IObservable<float> OnHealedAsObservable();
        /// <summary>
        /// 回復を実行する
        /// </summary>
        /// <param name="healPoint">回復量</param>
        void Heal(float healPoint);
    }
}