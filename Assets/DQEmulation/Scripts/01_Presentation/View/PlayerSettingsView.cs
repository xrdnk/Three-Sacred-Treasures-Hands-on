using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    /// <summary>
    /// プレイヤー側が行う設定
    /// </summary>
    public class PlayerSettingsView : MonoBehaviour
    {
        [SerializeField]
        private Slider _bgmSlider;

        // SFXの音量を調整する為のスライダを作ろう
        // private Slider _sfxSlider;

        public IObservable<float> OnSliderMovedAsObservable() => _onSliderMovedSubject;
        private Subject<float> _onSliderMovedSubject = new Subject<float>();

        // SFX調整用のスライダが移動した時に発火させるSubject(IObservable)を作ろう

        private void Awake()
        {
            _bgmSlider.OnValueChangedAsObservable()
                .Subscribe(_onSliderMovedSubject.OnNext)
                .AddTo(this);

            // SFX調整用のスライダが移動した時にSubscribeし，Model側に通知しよう
        }

        public void AdjustBGMSlider(float value)
        {
            _bgmSlider.value = value;
        }

        // Model側からSFXの音量が変化した時に，その値の変化をSlider表示に反映しよう
        // public void AdjustSFXSlider(float value)
        // {
        //
        // }
    }
}