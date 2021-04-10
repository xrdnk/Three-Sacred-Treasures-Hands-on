using System;

namespace Denik.DQEmulation.Model
{
    public interface IHealable
    {
        void Heal(int healPoint);
        IObservable<(string, int)> OnHealedAsObservable();
        int HealPower { get; }
    }
}