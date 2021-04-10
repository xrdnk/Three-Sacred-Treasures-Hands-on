using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Denik.DQEmulation.Consts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    public class EnemyView : MonoBehaviour, IAttackTrigger
    {
        [SerializeField]
        private Button _buttonAttack = default;
        [SerializeField]
        private Text _textName = default;
        [SerializeField]
        private Text _textHp = default;
        [SerializeField]
        private Image _imageFigure = default;

        private CancellationTokenSource cts = new CancellationTokenSource();

        public IObservable<Unit> OnAttackTriggerAsObservable() => _attackTriggerSubject;
        private Subject<Unit> _attackTriggerSubject = new Subject<Unit>();

        private void Awake()
        {
            _buttonAttack.OnClickAsObservable()
                .Subscribe(_  => _attackTriggerSubject.OnNext(Unit.Default))
                .AddTo(this);

            // ボタン押下後，1秒間ボタン無効にする
            _buttonAttack
                .BindToOnClick(_ => Observable.Timer(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND)).AsUnitObservable())
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

        public async void DisplayAttacked(string enemyName, string playerName, int damagePoint)
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

        public void DisplayFigure(Sprite figure)
        {
            _imageFigure.sprite = figure;
        }
    }
}