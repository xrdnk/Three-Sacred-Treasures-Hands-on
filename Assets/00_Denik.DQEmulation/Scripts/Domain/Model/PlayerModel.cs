using System;
using DenikProject.DQEmulation.Repository;
using UniRx;
using UnityEngine;

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

        private PlayerRepository _playerRepository;

        [Zenject.Inject]
        [VContainer.Inject]
        private void Construct(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            var entity = _playerRepository.PlayerEntity;
            (_maxHitPoint, _playerName, _damagePower, _healPower) =
                (entity.MaxHitPoint, entity.Name, entity.DamagePower, entity.HealPower);
            _hitPoint.Value = _maxHitPoint;
        }

        private void Awake()
        {
            // _maxHitPoint = _playerRepository.PlayerEntity.MaxHitPoint;
            // _hitPoint.Value = _maxHitPoint;
            // _playerName = _playerRepository.PlayerEntity.Name;
            // _damagePower = _playerRepository.PlayerEntity.DamagePower;
            // _healPower = _playerRepository.PlayerEntity.HealPower;
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