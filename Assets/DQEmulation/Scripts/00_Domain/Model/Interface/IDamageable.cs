using System;

namespace Denik.DQEmulation.Model
{
    public interface IDamageable
    {
        /// <summary>
        /// 攻撃力
        /// </summary>
        float AttackPower { get; }
        /// <summary>
        /// 攻撃されたことを通知する
        /// </summary>
        /// <returns>攻撃者の攻撃力</returns>
        IObservable<float> OnDamagedAsObservable();
        /// <summary>
        /// ダメージを受けたことを購読する
        /// </summary>
        /// <param name="attackerName">攻撃者の名前</param>
        /// <param name="damagePoint">攻撃者の攻撃力</param>
        void TakeDamage(string attackerName, float damagePoint);
    }
}