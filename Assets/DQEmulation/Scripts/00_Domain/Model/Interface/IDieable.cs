using System;

namespace Denik.DQEmulation.Model
{
    public interface IDieable
    {
        /// <summary>
        /// 殺されたことを通知する
        /// </summary>
        /// <returns>攻撃者</returns>
        IObservable<string> OnDiedAsObservable();
    }
}