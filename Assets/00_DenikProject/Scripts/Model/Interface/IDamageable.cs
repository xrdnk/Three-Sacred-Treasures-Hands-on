using System;

namespace DenikProject.DQEmulation.Model
{
    public interface IDamageable
    {
        void TakeDamage(string playerName, int damagePoint);
        IObservable<(string, string, int)> OnDamagedAsObservable();
        int DamagePower { get; }
    }
}