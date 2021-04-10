using System;
using System.Collections.Generic;
using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = nameof(PlayerData), menuName = "DQEmulation/" + nameof(PlayerData))]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private List<PlayerEntity> _playerEntities;

        public List<PlayerEntity> PlayerEntities => _playerEntities;
    }

    [Serializable]
    public class PlayerEntity
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