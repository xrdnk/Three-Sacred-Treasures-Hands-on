using System;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Model
{
    public class PlayerModel : MonoBehaviour, IPlayer
    {
        public IReadOnlyReactiveProperty<float> CurrentHitPoint => _hitPoint;
        private ReactiveProperty<float> _hitPoint = new ReactiveProperty<float>();

        public Sprite Figure => _figure;
        private Sprite _figure;

        public float MaxHitPoint => _maxHitPoint;
        private float _maxHitPoint;

        // MPのデータを持つようにしよう
        public IReadOnlyReactiveProperty<float> CurrentMagicPoint => _magicPoint;
        private ReactiveProperty<float> _magicPoint = new ReactiveProperty<float>();

        public float MaxMagicPoint => _maxMagicPoint;
        private float _maxMagicPoint;

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
            (_figure, _maxHitPoint, _playerName, _damagePower, _healPower, _maxMagicPoint)
                = (entity.Figure, entity.MaxHitPoint, entity.Name, entity.AttackPower, entity.HealPower, entity.MaxMagicPoint);
            _hitPoint.Value = _maxHitPoint;
            _magicPoint.Value = _maxMagicPoint;
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
            // HP の TakeDamage と同じ要領で MP減少処理を加えよう
            // 余裕があれば，MPが0になった時にボタンを非活性にする，回復を唱えることが出来ないメッセージなどを独自に加えよう
            if (_magicPoint.Value <= 0)
            {
                Debug.Log("MPがゼロです．");
                _magicPoint.Value = 0;
            }
            else
            {
                _magicPoint.Value -= 50;
                _hitPoint.Value += healPoint;
                _healedSubject.OnNext(healPoint);

                if (_hitPoint.Value > _maxHitPoint)
                {
                    _hitPoint.Value = _maxHitPoint;
                }
            }
        }
    }
}