using System;

namespace Denik.DQEmulation.Model
{
    public interface IDamageable
    {
        int DamagePower { get; }
        IObservable<(string, string, int)> OnDamagedAsObservable();
        void TakeDamage(string playerName, int damagePoint);
    }
}