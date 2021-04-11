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

                // OnCountAsObservable が発火された時

                // 購読し，Modelにインクリメントを通知する


            // Modelを参照する

                // カウンタの値が変化した時

                // 値の変化をViewに通知する

        }
    }
}