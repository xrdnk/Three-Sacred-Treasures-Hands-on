using UniRx;
using UnityEngine;

namespace Denik.UniRxPractice.Question4
{
    public class Presenter_Question : MonoBehaviour
    {
        [SerializeField]
        private Model_Question _model;
        [SerializeField]
        private View_Question _view;

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
                .Subscribe(_view.DisplayCounter)
                .AddTo(this);
        }
    }
}