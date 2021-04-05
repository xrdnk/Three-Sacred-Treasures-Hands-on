using System;
using UniRx;

namespace DenikProject.DQEmulation.View
{
    public interface IHealTrigger
    {
        IObservable<Unit> OnHealTriggerAsObservable();
    }
}