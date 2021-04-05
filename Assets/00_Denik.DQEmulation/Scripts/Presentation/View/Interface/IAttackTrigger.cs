using System;
using UniRx;

namespace DenikProject.DQEmulation.View
{
    public interface IAttackTrigger
    {
        IObservable<Unit> OnAttackTriggerAsObservable();
    }
}