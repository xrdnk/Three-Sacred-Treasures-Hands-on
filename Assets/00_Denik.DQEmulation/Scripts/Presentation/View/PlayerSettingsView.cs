using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    public class PlayerSettingsView : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        public IObservable<float> OnSliderMovedAsObservable() => _onSliderMovedSubject;
        private Subject<float> _onSliderMovedSubject = new Subject<float>();

        private void Awake()
        {
            _slider.OnValueChangedAsObservable()
                .Subscribe(_onSliderMovedSubject.OnNext)
                .AddTo(this);
        }

        public void AdjustSlider(float value)
        {
            _slider.value = value;
        }
    }
}