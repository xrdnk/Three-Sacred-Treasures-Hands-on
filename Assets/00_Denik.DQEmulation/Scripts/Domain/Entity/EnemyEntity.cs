using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = "EnemyEntity", menuName = "DQEmulation/EnemyEntity")]
    public class EnemyEntity : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _figure;
        [SerializeField]
        private int _damagePower;
        [SerializeField]
        private int _maxHitPoint;

        public string Name => _name;
        public Sprite Figure => _figure;
        public int DamagePower => _damagePower;
        public int MaxHitPoint => _maxHitPoint;
    }
}