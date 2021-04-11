using UniRx;
using UnityEngine;

namespace Denik.UniRxPractice.Question2
{
    public class Observer_Question : MonoBehaviour
    {
        [SerializeField]
        private Observable_Question _observable;

        private void Awake()
        {
            // Observableを参照する

                // OnHelloWorldAsObservable.OnNext が発火された時

                // 購読して，Debug.Log で表示する

        }
    }
}