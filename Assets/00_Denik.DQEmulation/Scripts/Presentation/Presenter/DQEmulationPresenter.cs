using System;
using DenikProject.DQEmulation.Model;
using DenikProject.DQEmulation.View;
using UniRx;

namespace DenikProject.DQEmulation.Presenter
{
    public class DQEmulationPresenter : Zenject.IInitializable, VContainer.Unity.IPostStartable, IDisposable
    {
        private PlayerModel _playerModel;
        private EnemyModel _enemyModel;
        private PlayerView _playerView;
        private EnemyView _enemyView;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [VContainer.Inject]
        [Zenject.Inject]
        private void Construct
            (PlayerModel playerModel, EnemyModel enemyModel, PlayerView playerView, EnemyView enemyView)
        {
            _playerModel = playerModel;
            _enemyModel = enemyModel;
            _playerView = playerView;
            _enemyView = enemyView;
        }

        /// <summary>
        /// Extenject の Initialize() メソッド
        /// タイミング的に処理が遅れる時があるので注意
        /// </summary>
        public void Initialize()
        {
            // Enemy View -> Models
            _enemyView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _playerModel.TakeDamage(_enemyModel.Name, _enemyModel.DamagePower))
                .AddTo(_compositeDisposable);
            _enemyView.DisplayName(_enemyModel.Name);

            // Enemy Model -> Views
            _enemyModel.HitPoint
                .Subscribe(_enemyView.DisplayHp)
                .AddTo(_compositeDisposable);
            _enemyModel.OnDamagedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayAttack(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(_compositeDisposable);
            _enemyModel.OnDiedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(_compositeDisposable);

            // Player View -> Models
            _playerView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _enemyModel.TakeDamage(_playerModel.Name, _playerModel.DamagePower))
                .AddTo(_compositeDisposable);
            _playerView.OnHealTriggerAsObservable()
                .Subscribe(_ => _playerModel.Heal(_playerModel.HealPower));
            _playerView.DisplayName(_playerModel.Name);

            // Player Model -> Views
            _playerModel.HitPoint
                .Subscribe(_playerView.DisplayHp)
                .AddTo(_compositeDisposable);
            _playerModel.OnDamagedAsObservable()
                .Subscribe(tuple => _playerView.DisplayAttacked(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(_compositeDisposable);
            _playerModel.OnDiedAsObservable()
                .Subscribe(tuple => _playerView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(_compositeDisposable);
            _playerModel.OnHealedAsObservable()
                .Subscribe(tuple => _playerView.DisplayHealed(tuple.Item1, tuple.Item2));
        }

        /// <summary>
        /// VContainer の Start()メソッド
        /// </summary>
        public void PostStart()
        {
            // Enemy View -> Models
            _enemyView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _playerModel.TakeDamage(_enemyModel.Name, _enemyModel.DamagePower))
                .AddTo(_compositeDisposable);
            _enemyView.DisplayName(_enemyModel.Name);

            // Enemy Model -> Views
            _enemyModel.HitPoint
                .Subscribe(_enemyView.DisplayHp)
                .AddTo(_compositeDisposable);
            _enemyModel.OnDamagedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayAttack(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(_compositeDisposable);
            _enemyModel.OnDiedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(_compositeDisposable);

            // Player View -> Models
            _playerView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _enemyModel.TakeDamage(_playerModel.Name, _playerModel.DamagePower))
                .AddTo(_compositeDisposable);
            _playerView.OnHealTriggerAsObservable()
                .Subscribe(_ => _playerModel.Heal(_playerModel.HealPower));
            _playerView.DisplayName(_playerModel.Name);

            // Player Model -> Views
            _playerModel.HitPoint
                .Subscribe(_playerView.DisplayHp)
                .AddTo(_compositeDisposable);
            _playerModel.OnDamagedAsObservable()
                .Subscribe(tuple => _playerView.DisplayAttacked(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(_compositeDisposable);
            _playerModel.OnDiedAsObservable()
                .Subscribe(tuple => _playerView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(_compositeDisposable);
            _playerModel.OnHealedAsObservable()
                .Subscribe(tuple => _playerView.DisplayHealed(tuple.Item1, tuple.Item2));
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}