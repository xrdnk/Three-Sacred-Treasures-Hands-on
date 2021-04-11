using System;
using Denik.DQEmulation.Consts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField]
        private Button _buttonAttack = default;
        [SerializeField]
        private Text _textName = default;
        [SerializeField]
        private Text _textHp = default;
        [SerializeField]
        private Image _imageFigure = default;

        private string _enemyName;

        public IObservable<string> OnAttackTriggerAsObservable() => _attackTriggerSubject;
        private Subject<string> _attackTriggerSubject = new Subject<string>();

        private void Awake()
        {
            _buttonAttack.OnClickAsObservable()
                .Subscribe(_  => _attackTriggerSubject.OnNext(_enemyName))
                .AddTo(this);

            // ボタン押下後，1秒間ボタン無効にする
            _buttonAttack
                .BindToOnClick(_ => Observable.Timer(TimeSpan.FromSeconds(DQEmulatorConsts.DISPLAY_DELAY_SECOND)).AsUnitObservable())
                .AddTo(this);
        }

        public void DisplayHp(float hp)
        {
            _textHp.text = string.Empty;
            _textHp.text = $"HP : {hp}";
        }

        public void DisplayName(string enemyName)
        {
            _enemyName = enemyName;
            _textName.text = string.Empty;
            _textName.text = $"{_enemyName}";
        }

        public void DisplayFigure(Sprite figure)
        {
            _imageFigure.sprite = figure;
        }

        public void DisplayDamaged(float damagedPoint)
        {
            Debug.Log($"{_enemyName} は {damagedPoint} のダメージ！");
        }

        public void DisplayDied(string killedName)
        {
            Debug.Log($"{_enemyName} は {killedName} に倒された．");
            gameObject.SetActive(false);
        }

    }
}