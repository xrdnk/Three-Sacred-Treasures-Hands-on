using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public interface ICreature
    {
        string Name { get; }
        Sprite Figure { get; }
        IReadOnlyReactiveProperty<int> HitPoint { get; }
        // HP最大値が上昇する場合，ReactiveProperty 化するのがよい
        int MaxHitPoint { get; }
        // 今回はMPを省ているが，HPと同じ要領で定義する
    }
}