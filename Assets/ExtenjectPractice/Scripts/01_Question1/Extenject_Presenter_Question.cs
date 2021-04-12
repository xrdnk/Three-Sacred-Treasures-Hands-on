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
        private void Construct(Extenject_Model_Question model, Extenject_View_Question view)
        {
            _model = model;
            _view = view;
        }

        private void Awake()
        {
            // Viewを参照する

                // OnCountAsObservable が発火された時

                // 購読し，Modelにインクリメントを通知する


            // Modelを参照する

                // カウンタの値が変化した時

                // 値の変化をViewに通知する

        }
    }
}