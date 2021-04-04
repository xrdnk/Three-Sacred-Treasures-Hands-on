using DenikProject.DQEmulation.Model;
using DenikProject.DQEmulation.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace DenikProject.DQEmulation.Presenter
{
    public class DQEmulationPresenter : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private EnemyModel _enemyModel;
        private PlayerView _playerView;
        private EnemyView _enemyView;

        // private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [Inject]
        private void Construct
            (PlayerModel playerModel, EnemyModel enemyModel, PlayerView playerView, EnemyView enemyView)
        {
            _playerModel = playerModel;
            _enemyModel = enemyModel;
            _playerView = playerView;
            _enemyView = enemyView;
        }

        public void Start()
        {
            // Enemy View -> Models
            _enemyView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _playerModel.TakeDamage(_enemyModel.Name, _enemyModel.DamagePower))
                .AddTo(this);
            _enemyView.DisplayName(_enemyModel.Name);

            // Enemy Model -> Views
            _enemyModel.HitPoint
                .Subscribe(_enemyView.DisplayHp)
                .AddTo(this);
            _enemyModel.OnDamagedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayAttack(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(this);
            _enemyModel.OnDiedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(this);

            // Player View -> Models
            _playerView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _enemyModel.TakeDamage(_playerModel.Name, _playerModel.DamagePower))
                .AddTo(this);
            _playerView.OnHealTriggerAsObservable()
                .Subscribe(_ => _playerModel.Heal(_playerModel.HealPower));
            _playerView.DisplayName(_playerModel.Name);

            // Player Model -> Views
            _playerModel.HitPoint
                .Subscribe(_playerView.DisplayHp)
                .AddTo(this);
            _playerModel.OnDamagedAsObservable()
                .Subscribe(tuple => _playerView.DisplayAttacked(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(this);
            _playerModel.OnDiedAsObservable()
                .Subscribe(tuple => _playerView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(this);
            _playerModel.OnHealedAsObservable()
                .Subscribe(tuple => _playerView.DisplayHealed(tuple.Item1, tuple.Item2));
        }
    }
}