﻿using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace DenikProject.DQEmulation.Model
{
    public class PlayerModel : MonoBehaviour, IPlayer
    {
        public IReadOnlyReactiveProperty<int> HitPoint => _hitPoint;
        private ReactiveProperty<int> _hitPoint = new ReactiveProperty<int>();

        public int MaxHitPoint => _maxHitPoint;
        private int _maxHitPoint;

        public string Name => _playerName;
        private string _playerName;

        public int DamagePower => _damagePower;
        private int _damagePower;

        public int HealPower => _healPower;
        private int _healPower;

        public IObservable<(string, int)> OnHealedAsObservable() => _healedSubject;
        private Subject<(string, int)> _healedSubject = new Subject<(string, int)>();

        public IObservable<(string, string, int)> OnDamagedAsObservable() => _damagedSubject;
        private Subject<(string, string, int)> _damagedSubject = new Subject<(string, string, int)>();

        public IObservable<(string, string)> OnDiedAsObservable() => _diedSubject;
        private Subject<(string, string)> _diedSubject = new Subject<(string, string)>();

        private PlayerResourceProvider _playerResourceProvider;

        [Inject]
        private void Construct(PlayerResourceProvider playerResourceProvider)
        {
            _playerResourceProvider = playerResourceProvider;
        }

        private void Awake()
        {
            _maxHitPoint = _playerResourceProvider.PlayerEntity.MaxHitPoint;
            _hitPoint.Value = _maxHitPoint;
            _playerName = _playerResourceProvider.PlayerEntity.Name;
            _damagePower = _playerResourceProvider.PlayerEntity.DamagePower;
            _healPower = _playerResourceProvider.PlayerEntity.HealPower;
        }

        public void TakeDamage(string enemyName, int damagePoint)
        {
            _hitPoint.Value -= damagePoint;
            _damagedSubject.OnNext((enemyName, _playerName, damagePoint));

            if (_hitPoint.Value <= 0)
            {
                Die(enemyName);
            }
        }

        private void Die(string enemyName)
        {
            _diedSubject.OnNext((_playerName, enemyName));
        }

        public void Heal(int healPoint)
        {
            _hitPoint.Value += healPoint;
            _healedSubject.OnNext((_playerName, healPoint));

            if (_hitPoint.Value > _maxHitPoint)
            {
                _hitPoint.Value = _maxHitPoint;
            }
        }

    }
}