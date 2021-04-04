using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DenikProject.DQEmulation.Consts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace DenikProject.DQEmulation.View
{
    public class PlayerView : MonoBehaviour, IAttackTrigger, IHealTrigger
    {
        [SerializeField]
        private Button _buttonAttack = default;
        [SerializeField]
        private Button _buttonHeal = default;
        [SerializeField]
        private Text _TextName = default;
        [SerializeField]
        private Text _TextHp = default;

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
                    await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND));
                    _buttonAttack.interactable = true;
                }))
                .AddTo(this);

            _buttonHeal.OnClickAsObservable()
                .Subscribe(_ => _healTriggerSubject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void DisplayName(string enemyName)
        {
            _TextName.text = string.Empty;
            _TextName.text = $"{enemyName}";
        }

        public void DisplayHp(int hp)
        {
            _TextHp.text = string.Empty;
            _TextHp.text = $"HP : {hp}";
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
    }
}