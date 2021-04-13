using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public interface ICreature
    {
        string Name { get; }
        Sprite Figure { get; }
    }
}