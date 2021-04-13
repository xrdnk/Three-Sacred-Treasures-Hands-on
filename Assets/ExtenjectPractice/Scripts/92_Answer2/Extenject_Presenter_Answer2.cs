using UniRx;
using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Answer2
{
    public class Extenject_Presenter_Answer2 : MonoBehaviour
    {
        private Extenject_Model_Answer2 _model;
        private Extenject_View_Answer2 _view;

        [Inject]
        private void Construct(Extenject_Model_Answer2 model, Extenject_View_Answer2 view)
        {
            _model = model;
            _view = view;
        }

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