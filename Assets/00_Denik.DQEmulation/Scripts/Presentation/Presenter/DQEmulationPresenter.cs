using System;
using Denik.DQEmulation.Model;
using Denik.DQEmulation.Service;
using Denik.DQEmulation.View;
using UniRx;

namespace Denik.DQEmulation.Presenter
{
    public class DQEmulationPresenter : Zenject.IInitializable, VContainer.Unity.IPostStartable, IDisposable
    {
        private PlayerModel _playerModel;
        private EnemyModel _enemyModel;
        private PlayerView _playerView;
        private EnemyView _enemyView;
        private BGMPlayer _bgmPlayer;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [VContainer.Inject]
        [Zenject.Inject]
        private void Construct
            (PlayerModel playerModel, EnemyModel enemyModel, PlayerView playerView, EnemyView enemyView,
            BGMPlayer bgmPlayer)
        {
            _playerModel = playerModel;
            _enemyModel = enemyModel;
            _playerView = playerView;
            _enemyView = enemyView;
            _bgmPlayer = bgmPlayer;
        }

        /// <summary>
        /// Extenject の Initialize() メソッド
        /// タイミング的に処理が遅れる時があるので注意
        /// </summary>
        public void Initialize()
        {
            Present();
        }

        /// <summary>
        /// VContainer の Start()メソッド
        /// </summary>
        public void PostStart()
        {
            Present();
        }

        private void Present()
        {
            // Enemy Model -> Views
            _enemyModel.HitPoint
                .Subscribe(_enemyView.DisplayHp)
                .AddTo(_compositeDisposable);
            _enemyModel.OnDamagedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayAttacked(tuple.Item1, tuple.Item2, tuple.Item3))
                .AddTo(_compositeDisposable);
            _enemyModel.OnDiedAsObservable()
                .Subscribe(tuple => _enemyView.DisplayDied(tuple.Item1, tuple.Item2))
                .AddTo(_compositeDisposable);

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

            // Enemy View -> Models
            _enemyView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _playerModel.TakeDamage(_enemyModel.Name, _enemyModel.DamagePower))
                .AddTo(_compositeDisposable);
            _enemyView.DisplayName(_enemyModel.Name);
            _enemyView.DisplayFigure(_enemyModel.Figure);

            // Player View -> Models
            _playerView.OnAttackTriggerAsObservable()
                .Subscribe(_ => _enemyModel.TakeDamage(_playerModel.Name, _playerModel.DamagePower))
                .AddTo(_compositeDisposable);
            _playerView.OnHealTriggerAsObservable()
                .Subscribe(_ => _playerModel.Heal(_playerModel.HealPower));
            _playerView.DisplayName(_playerModel.Name);
            _playerView.DisplayFigure(_playerModel.Figure);

            _bgmPlayer.Play();
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}