using UniRx;
using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Question1
{
    public class Extenject_Presenter_Question : MonoBehaviour
    {
        private Extenject_Model_Question _model;
        private Extenject_View_Question _view;

        // MonoBehaviour継承クラスは new が出来ない関係上，
        // コンストラクタインジェクションは出来ない．
        // よって，メソッドインジェクションを利用する必要がある
        // メソッドインジェクションを行う場合は [Inject] アトリビュートを付与する
        [Inject]
        private void Construct(Extenject_Model_Question model, Extenject_View_Question view)
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