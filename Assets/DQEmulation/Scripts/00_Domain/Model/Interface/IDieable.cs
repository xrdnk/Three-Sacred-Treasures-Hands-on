using System;

namespace Denik.DQEmulation.Model
{
    public interface IDieable
    {
        IObservable<(string, string)> OnDiedAsObservable();
    }
}