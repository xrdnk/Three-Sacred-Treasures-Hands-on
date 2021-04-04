using System;

namespace DenikProject.DQEmulation.Model
{
    public interface IHealable
    {
        void Heal(int healPoint);
        IObservable<(string, int)> OnHealedAsObservable();
        int HealPower { get; }
    }
}