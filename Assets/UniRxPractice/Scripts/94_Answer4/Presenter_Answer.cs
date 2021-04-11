using UniRx;
using UnityEngine;

namespace Denik.UniRxPractice.Answer4
{
    public class Presenter_Answer : MonoBehaviour
    {
        [SerializeField]
        private Model_Answer _model;
        [SerializeField]
        private View_Answer _view;

        private void Awake()
        {
            // Viewを参照する
            _view
                // OnCountAsObservable が発火された時
                .OnCountAsObservable()
                // 購読し，Modelにインクリメントを通知する
                .Subscribe(_ => _model.IncrementCount())
                .AddTo(this);

            // Modelを参照する
            _model
                // カウンタの値が変化した時
                .Counter
                // 値の変化をViewに通知する
                .Subscribe(count => _view.DisplayCounter(count))
                .AddTo(this);
        }
    }
}