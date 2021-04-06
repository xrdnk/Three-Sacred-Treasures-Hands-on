using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = "PlayerEntity", menuName = "DQEmulation/PlayerEntity")]
    public class PlayerEntity : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _figure;
        [SerializeField]
        private int _maxHitPoint;
        [SerializeField]
        private int _damagePower;
        [SerializeField]
        private int _healPower;

        public string Name => _name;
        public Sprite Figure => _figure;
        public int MaxHitPoint => _maxHitPoint;
        public int DamagePower => _damagePower;
        public int HealPower => _healPower;
    }
}