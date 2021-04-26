using System;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Denik.ExtenjectPractice.Question2
{
    public class Extenject_Presenter_Question2 : IStartable, IDisposable
    {
        private Extenject_Model_Question2 _model;
        private Extenject_View_Question2 _view;

        [Inject]
        private Extenject_Presenter_Question2(Extenject_Model_Question2 model, Extenject_View_Question2 view)
        {
            _model = model;
            _view = view;
        }

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        void IStartable.Start()
        {
            // Viewを参照する
            _view
                // OnCountAsObservable が発火された時
                .OnCountAsObservable()
                // 購読し，Modelにインクリメントを通知する
                .Subscribe(_ => _model.IncrementCount())
                .AddTo(_compositeDisposable);

            // Modelを参照する
            _model
                // カウンタの値が変化した時
                .Counter
                // 値の変化をViewに通知する
                .Subscribe(count => _view.DisplayCounter(count))
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}