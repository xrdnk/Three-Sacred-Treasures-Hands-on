using System;
using Denik.DQEmulation.Model;
using Denik.DQEmulation.Service;
using Denik.DQEmulation.View;
using UniRx;

namespace Denik.DQEmulation.Presenter
{
    public class DQEmulationPresenter : Zenject.IInitializable, VContainer.Unity.IPostStartable, IDisposable
    {
        private IPlayer _player;
        private IEnemy _enemy;
        private IPlayerView _playerView;
        private IEnemyView _enemyView;
        private BGMPlayer _bgmPlayer;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [VContainer.Inject]
        [Zenject.Inject]
        private void Construct(
            IPlayer playerModel, IEnemy enemyModel,
            IPlayerView playerView, IEnemyView enemyView,
            BGMPlayer bgmPlayer
            )
        {
            _player = playerModel;
            _enemy = enemyModel;
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
            // 敵の名前をViewに表示する
            _enemyView.DisplayName(_enemy.Name);
            // 敵の姿をViewに表示する
            _enemyView.DisplayFigure(_enemy.Figure);
            // 敵のHPをViewに表示する
            _enemy.HitPoint
                .Subscribe(_enemyView.DisplayHp)
                .AddTo(_compositeDisposable);
            // 敵が攻撃を受けたことをViewに通知する
            _enemy.OnDamagedAsObservable()
                .Subscribe(damagedPoint => _enemyView.DisplayDamaged(damagedPoint))
                .AddTo(_compositeDisposable);
            // 敵が殺されたことをViewに通知する
            _enemy.OnDiedAsObservable()
                .Subscribe(attackerName => _enemyView.DisplayDied(attackerName))
                .AddTo(_compositeDisposable);

            // Player Model -> Views
            // プレイヤーの名前をViewに表示する
            _playerView.DisplayName(_player.Name);
            // プレイヤーの姿をViewに表示する
            _playerView.DisplayFigure(_player.Figure);
            // プレイヤーのHPをViewに表示する
            _player.HitPoint
                .Subscribe(_playerView.DisplayHp)
                .AddTo(_compositeDisposable);
            // プレイヤーが攻撃されたことをViewに通知する
            _player.OnDamagedAsObservable()
                .Subscribe(damagedPoint => _playerView.DisplayDamaged(damagedPoint))
                .AddTo(_compositeDisposable);
            // プレイヤーが死んだことをViewに通知する
            _player.OnDiedAsObservable()
                .Subscribe(attackerName => _playerView.DisplayDied(attackerName))
                .AddTo(_compositeDisposable);
            // プレイヤーが回復したことをViewに通知する
            _player.OnHealedAsObservable()
                .Subscribe(healedPoint => _playerView.DisplayHealed(healedPoint))
                .AddTo(_compositeDisposable);

            // Enemy View -> Models
            // 敵が攻撃したことをModelに通知する
            _enemyView.OnAttackTriggerAsObservable()
                .Subscribe(attackerName => _player.TakeDamage(attackerName, _enemy.AttackPower))
                .AddTo(_compositeDisposable);

            // Player View -> Models
            // プレイヤーが攻撃したことを通知する
            _playerView.OnAttackTriggerAsObservable()
                .Subscribe(attackerName => _enemy.TakeDamage(attackerName, _player.AttackPower))
                .AddTo(_compositeDisposable);
            // プレイヤーが回復魔法を唱えたことを通知する
            _playerView.OnHealTriggerAsObservable()
                .Subscribe(_ => _player.Heal(_player.HealPower))
                .AddTo(_compositeDisposable);

            // 今回は一時的にここにBGM再生処理を行う
            _bgmPlayer.Play();
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}