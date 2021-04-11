using UnityEngine;
using UnityEngine.UI;

namespace DQEmulation.GodEvil
{
    public class PlayerGodClass : MonoBehaviour
    {
        [Header("入出力用のUIコンポーネント群")]
        [SerializeField, Tooltip("攻撃ボタン")] private Button _buttonAttack = default;
        [SerializeField, Tooltip("回復ボタン")] private Button _buttonHeal = default;
        [SerializeField, Tooltip("名前テキスト")] private Text _textName = default;
        [SerializeField, Tooltip("HPテキスト")] private Text _textHp = default;
        [SerializeField, Tooltip("プレイヤーの姿を表示するためのイメージ")] private Image _imageFigure = default;

        [Header("プレイヤー用の素材")]
        [SerializeField, Tooltip("プレイヤーの姿の素材")] private Sprite _spriteFigure = default;
        [SerializeField, Tooltip("プレイヤーの名前")] private string _playerName = default;
        [SerializeField, Tooltip("プレイヤーの攻撃力")] private float _playerAttackPower = default;
        [SerializeField, Tooltip("プレイヤーの回復力")] private float _playerHealPower = default;
        [SerializeField, Tooltip("プレイヤーの最大HP")] private float _playerMaxHitPoint = default;

        private event AttackHandler _onAttackTrigger;
        private delegate void AttackHandler(string attackerName, float attackPower);

        private event HealHandler _onHealTrigger;
        private delegate void HealHandler(string healerName, float healPower);

        private float _currentHitPoint;

        private void Awake()
        {
            UISet();
            _buttonAttack.onClick.AddListener(Attack);
            _buttonHeal.onClick.AddListener(Heal);
        }

        private void UISet()
        {
            _textName.text = _playerName;
            _currentHitPoint = _playerMaxHitPoint;
            _textHp.text = $"{_currentHitPoint}";
            _imageFigure.sprite = _spriteFigure;
        }

        private void Attack()
        {
            Debug.Log($"{_playerName} の攻撃！");
            _onAttackTrigger?.Invoke(_playerName, _playerAttackPower);
        }

        private void Heal()
        {
            Debug.Log($"{_playerName} はホイミを唱えた．");
            _onHealTrigger?.Invoke(_playerName, _playerHealPower);
        }

        private void Damaged(float damagedPoint)
        {
            _currentHitPoint -= damagedPoint;
            Debug.Log($"{_playerName} は {damagedPoint} のダメージを受けた．");
            if (_currentHitPoint <= 0)
            {
                _currentHitPoint = 0;
                Die();
            }
        }

        private void Healed(float healedPoint)
        {
            _currentHitPoint += healedPoint;
            Debug.Log($"{_playerName} は {healedPoint} 回復した．");
            if (_currentHitPoint >= _playerMaxHitPoint)
            {
                _currentHitPoint = _playerMaxHitPoint;
            }
        }

        private void Die()
        {
            Debug.Log($"{_playerName} は死んだ．");
            DestroyImmediate(this);
        }
    }
}