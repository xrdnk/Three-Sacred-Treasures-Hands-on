using System;
using Cysharp.Threading.Tasks;
using Denik.DQEmulation.Consts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField]
        private Button _buttonAttack = default;
        [SerializeField]
        private Button _buttonHeal = default;
        [SerializeField]
        private Text _textName = default;
        [SerializeField]
        private Text _textHp = default;
        [SerializeField]
        private Image _imageFigure = default;

        private string _playerName;

        public IObservable<string> OnAttackTriggerAsObservable() => _attackTriggerSubject;
        private Subject<string> _attackTriggerSubject = new Subject<string>();

        public IObservable<string> OnHealTriggerAsObservable() => _healTriggerSubject;
        private Subject<string> _healTriggerSubject = new Subject<string>();

        private ReactiveProperty<bool> _sharedGate = new ReactiveProperty<bool>(true);

        private void Awake()
        {
            // ボタン押下後，1秒間ボタン無効にする
            _buttonAttack
                .BindToOnClick(_sharedGate, _ =>
                {
                    Debug.Log($"{_playerName} の攻撃！");
                    _attackTriggerSubject.OnNext(_playerName);
                    return Observable.Timer(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND))
                            .AsUnitObservable();
                })
                .AddTo(this);

            _buttonHeal
                .BindToOnClick(_sharedGate, _ =>
                {
                    Debug.Log($"{_playerName} は自身に回復を唱えた．");
                    _healTriggerSubject.OnNext(_playerName);
                    return Observable.Timer(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND))
                        .AsUnitObservable();
                })
                .AddTo(this);
        }

        public void DisplayHp(float hp)
        {
            _textHp.text = string.Empty;
            _textHp.text = $"HP : {hp}";
        }

        public void DisplayName(string enemyName)
        {
            _textName.text = string.Empty;
            _playerName = enemyName;
            _textName.text = $"{_playerName}";
        }

        public void DisplayFigure(Sprite figure)
        {
            _imageFigure.sprite = figure;
        }

        public async void DisplayDamaged(float damagedPoint)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND));
            Debug.Log($"{_playerName} に {damagedPoint} のダメージ！");
        }

        public async void DisplayHealed(float healedPoint)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND));
            Debug.Log($"{_playerName} は {healedPoint} 回復した！");
        }

        public async void DisplayDied(string killedName)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND));
            Debug.Log($"{_playerName} は {killedName} に倒されてしまった... ");
            gameObject.SetActive(false);
        }
    }
}