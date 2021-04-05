using UnityEngine;

namespace DenikProject.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = "EnemyEntity", menuName = "DQEmulation/EnemyEntity")]
    public class EnemyEntity : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private int _damagePower;

        [SerializeField]
        private int _maxHitPoint;

        public string Name => _name;
        public int DamagePower => _damagePower;
        public int MaxHitPoint => _maxHitPoint;
    }
}