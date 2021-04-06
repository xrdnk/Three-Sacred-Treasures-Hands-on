using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Denik.DQEmulation.Consts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    public class PlayerView : MonoBehaviour, IAttackTrigger, IHealTrigger
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

        private CancellationTokenSource cts = new CancellationTokenSource();

        public IObservable<Unit> OnAttackTriggerAsObservable() => _attackTriggerSubject;
        private Subject<Unit> _attackTriggerSubject = new Subject<Unit>();

        public IObservable<Unit> OnHealTriggerAsObservable() => _healTriggerSubject;
        private Subject<Unit> _healTriggerSubject = new Subject<Unit>();

        private void Awake()
        {
            _buttonAttack.OnClickAsObservable()
                .Subscribe(_ => UniTask.Void(async () =>
                {
                    _attackTriggerSubject.OnNext(Unit.Default);

                    // ここはもう少しスマートにしたい
                    _buttonAttack.interactable = false;
                    await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND), cancellationToken: cts.Token);
                    _buttonAttack.interactable = true;
                }))
                .AddTo(this);

            _buttonHeal.OnClickAsObservable()
                .Subscribe(_ => _healTriggerSubject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void DisplayName(string enemyName)
        {
            _textName.text = string.Empty;
            _textName.text = $"{enemyName}";
        }

        public void DisplayHp(int hp)
        {
            _textHp.text = string.Empty;
            _textHp.text = $"HP : {hp}";
        }

        public async void DisplayAttacked(string playerName, string enemyName, int damagePoint)
        {
            Debug.Log($"{playerName} のこうげき！");
            await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND), cancellationToken: cts.Token);
            Debug.Log($"{enemyName} に {damagePoint} のダメージ！");
        }

        public void DisplayDied(string playerName, string enemyName)
        {
            Debug.Log($"{playerName} は {enemyName} に倒されてしまった．");
            gameObject.SetActive(false);
        }

        public void DisplayHealed(string playerName, int healPoint)
        {
            Debug.Log($"{playerName} は {healPoint} 回復した！");
        }

        public void DisplayFigure(Sprite figure)
        {
            _imageFigure.sprite = figure;
        }
    }
}