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
    public class EnemyView : MonoBehaviour, IAttackTrigger
    {
        [SerializeField]
        private Button _buttonAttack = default;
        [SerializeField]
        private Text _TextName = default;
        [SerializeField]
        private Text _TextHp = default;

        private CancellationTokenSource cts = new CancellationTokenSource();

        public IObservable<Unit> OnAttackTriggerAsObservable() => _attackTriggerSubject;
        private Subject<Unit> _attackTriggerSubject = new Subject<Unit>();

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

        public async void DisplayAttack(string enemyName, string playerName, int damagePoint)
        {
            Debug.Log($"{enemyName} のこうげき！");
            await UniTask.Delay(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND), cancellationToken: cts.Token);
            Debug.Log($"{playerName} に {damagePoint} のダメージ！");
        }

        public void DisplayDied(string enemyName, string playerName)
        {
            Debug.Log($"{playerName} は {enemyName} を倒した！");
            gameObject.SetActive(false);
        }
    }
}