using System;
using UniRx;

namespace Denik.DQEmulation.View
{
    public interface IAttackTrigger
    {
        IObservable<Unit> OnAttackTriggerAsObservable();
    }
}