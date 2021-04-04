using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace DenikProject.DQEmulation.Model
{
    public class EnemyModel : MonoBehaviour, IEnemy
    {
        public IReadOnlyReactiveProperty<int> HitPoint => _hitPoint;
        private ReactiveProperty<int> _hitPoint = new ReactiveProperty<int>();

        public int MaxHitPoint => _maxHitPoint;
        private int _maxHitPoint;

        public string Name => _enemyName;
        private string _enemyName;

        public int DamagePower => _damagePower;
        private int _damagePower;

        private EnemyResourceProvider _enemyResourceProvider;

        public IObservable<(string, string, int)> OnDamagedAsObservable() => _damagedSubject;
        private Subject<(string, string, int)> _damagedSubject = new Subject<(string, string, int)>();

        public IObservable<(string, string)> OnDiedAsObservable() => _diedSubject;
        private Subject<(string, string)> _diedSubject = new Subject<(string, string)>();

        [Inject]
        private void Construct(EnemyResourceProvider enemyResourceProvider)
        {
            _enemyResourceProvider = enemyResourceProvider;
        }

        private void Awake()
        {
            _maxHitPoint = _enemyResourceProvider.EnemyEntity.MaxHitPoint;
            _hitPoint.Value = _maxHitPoint;
            _enemyName = _enemyResourceProvider.EnemyEntity.Name;
            _damagePower = _enemyResourceProvider.EnemyEntity.DamagePower;
        }

        public void TakeDamage(string playerName, int damagePoint)
        {
            _hitPoint.Value -= damagePoint;
            _damagedSubject.OnNext((playerName, _enemyName, damagePoint));

            if (_hitPoint.Value <= 0)
            {
                Die(playerName);
            }
        }

        private void Die(string playerName)
        {
            _diedSubject.OnNext((_enemyName, playerName));
        }
    }
}