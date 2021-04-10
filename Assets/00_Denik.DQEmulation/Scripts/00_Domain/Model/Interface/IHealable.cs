using System;

namespace Denik.DQEmulation.Model
{
    public interface IHealable
    {
        int HealPower { get; }
        IObservable<(string, int)> OnHealedAsObservable();
        void Heal(int healPoint);
    }
}