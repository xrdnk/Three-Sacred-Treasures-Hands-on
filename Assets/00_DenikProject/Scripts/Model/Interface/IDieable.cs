using System;

namespace DenikProject.DQEmulation.Model
{
    public interface IDieable
    {
        IObservable<(string, string)> OnDiedAsObservable();
    }
}