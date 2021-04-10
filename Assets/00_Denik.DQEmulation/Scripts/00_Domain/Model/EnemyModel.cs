using System;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public class EnemyModel : MonoBehaviour, IEnemy
    {
        public IReadOnlyReactiveProperty<int> HitPoint => _hitPoint;
        private ReactiveProperty<int> _hitPoint = new ReactiveProperty<int>();

        public Sprite Figure => _figure;
        private Sprite _figure;

        public int MaxHitPoint => _maxHitPoint;
        private int _maxHitPoint;

        public string Name => _enemyName;
        private string _enemyName;

        public int DamagePower => _damagePower;
        private int _damagePower;

        private EnemyRepository _enemyRepository;

        public IObservable<(string, string, int)> OnDamagedAsObservable() => _damagedSubject;
        private readonly Subject<(string playerName, string enemyName, int damagePoint)> _damagedSubject = new Subject<(string, string, int)>();

        public IObservable<(string, string)> OnDiedAsObservable() => _diedSubject;
        private readonly Subject<(string enemyName, string playerName)> _diedSubject = new Subject<(string enemyName, string playerName)>();

        [Zenject.Inject]
        [VContainer.Inject]
        private void Construct(EnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
            var entity = _enemyRepository.EnemyEntities[0];
            (_figure, _maxHitPoint, _enemyName, _damagePower)
                = (entity.Figure, entity.MaxHitPoint, entity.Name, entity.DamagePower);
            _hitPoint.Value = _maxHitPoint;
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