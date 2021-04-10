using System;
using UniRx;

namespace Denik.DQEmulation.View
{
    public interface IHealTrigger
    {
        IObservable<Unit> OnHealTriggerAsObservable();
    }
}