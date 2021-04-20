using UnityEngine;
using UniRx;

namespace Denik.UniTaskPractice.Question2
{
    [RequireComponent(typeof(ProgressModel_Question))]
    [RequireComponent(typeof(ProgressView_Question))]
    public class ProgressPresenter_Question : MonoBehaviour
    {
        // Extenjectを用いる方が良い
        private ProgressModel_Question _progressModel;
        private ProgressView_Question _progressView;

        private void Awake()
        {
            TryGetComponent(out _progressModel);
            TryGetComponent(out _progressView);
        }

        private void Start()
        {
            // Viewにあるダウンロードボタンの押下時、Modelに通知する

            // Modelにある進捗率の値が変化した時、Viewに通知する
        }
    }
}