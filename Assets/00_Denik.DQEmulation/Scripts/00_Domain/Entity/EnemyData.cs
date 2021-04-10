using System;
using System.Collections.Generic;
using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = nameof(EnemyData), menuName = "DQEmulation/" + nameof(EnemyData))]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private List<EnemyEntity> _enemyEntities;
        public List<EnemyEntity> EnemyEntities => _enemyEntities;
    }

    [Serializable]
    public class EnemyEntity
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