using System;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public class PlayerModel : MonoBehaviour, IPlayer
    {
        public IReadOnlyReactiveProperty<float> HitPoint => _hitPoint;
        private ReactiveProperty<float> _hitPoint = new ReactiveProperty<float>();

        public Sprite Figure => _figure;
        private Sprite _figure;

        public float MaxHitPoint => _maxHitPoint;
        private float _maxHitPoint;

        public string Name => _playerName;
        private string _playerName;

        public float AttackPower => _damagePower;
        private float _damagePower;

        public float HealPower => _healPower;
        private float _healPower;

        public IObservable<float> OnHealedAsObservable() => _healedSubject;
        private Subject<float> _healedSubject = new Subject<float>();

        public IObservable<float> OnDamagedAsObservable() => _damagedSubject;
        private Subject<float> _damagedSubject = new Subject<float>();

        public IObservable<string> OnDiedAsObservable() => _diedSubject;
        private Subject<string> _diedSubject = new Subject<string>();

        private IPlayerRepository _playerRepository;

        [Zenject.Inject]
        [VContainer.Inject]
        private void Construct(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            var entity = _playerRepository.GetPlayerEntity(0);
            (_figure, _maxHitPoint, _playerName, _damagePower, _healPower)
                = (entity.Figure, entity.MaxHitPoint, entity.Name, entity.AttackPower, entity.HealPower);
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

        public void Heal(float healPoint)
        {
            _hitPoint.Value += healPoint;
            _healedSubject.OnNext(healPoint);

            if (_hitPoint.Value > _maxHitPoint)
            {
                _hitPoint.Value = _maxHitPoint;
            }
        }

    }
}