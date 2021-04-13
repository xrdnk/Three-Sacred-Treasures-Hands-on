using System;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public class EnemyModel : MonoBehaviour, IEnemy
    {
        public IReadOnlyReactiveProperty<float> CurrentHitPoint => _hitPoint;
        private ReactiveProperty<float> _hitPoint = new ReactiveProperty<float>();

        public Sprite Figure => _figure;
        private Sprite _figure;

        public float MaxHitPoint => _maxHitPoint;
        private float _maxHitPoint;

        public string Name => _enemyName;
        private string _enemyName;

        public float AttackPower => _attackePower;
        private float _attackePower;

        private IEnemyRepository _enemyRepository;

        public IObservable<float> OnDamagedAsObservable() => _damagedSubject;
        private readonly Subject<float> _damagedSubject = new Subject<float>();

        public IObservable<string> OnDiedAsObservable() => _diedSubject;
        private readonly Subject<string> _diedSubject = new Subject<string>();

        [Zenject.Inject]
        [VContainer.Inject]
        private void Construct(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
            var entity = _enemyRepository.GetEnemyEntity(0);
            (_figure, _maxHitPoint, _enemyName, _attackePower)
                = (entity.Figure, entity.MaxHitPoint, entity.Name, entity.AttackPower);
            _hitPoint.Value = _maxHitPoint;
        }

        public void TakeDamage(string attackerName, float damagePoint)
        {
            _hitPoint.Value -= damagePoint;
            _damagedSubject.OnNext(damagePoint);

            if (_hitPoint.Value <= 0)
            {
                Die(attackerName);
            }
        }

        private void Die(string attackerName)
        {
            _diedSubject.OnNext(attackerName);
        }
    }
}