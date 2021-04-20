using UnityEngine;
using UniRx;

namespace Denik.UniTaskPractice.Answer2
{
    [RequireComponent(typeof(ProgressModel_Answer))]
    [RequireComponent(typeof(ProgressView_Answer))]
    public class ProgressPresenter_Answer : MonoBehaviour
    {
        // Extenjectを用いる方が良い
        private ProgressModel_Answer _progressModel;
        private ProgressView_Answer _progressView;

        private void Awake()
        {
            TryGetComponent(out _progressModel);
            TryGetComponent(out _progressView);
        }

        private void Start()
        {
            // Viewにあるダウンロードボタンの押下時、Modelに通知する
            _progressView.OnDownloadButtonPushed.Subscribe(_ => _progressModel.DownloadContent());

            // Modelにある進捗率の値が変化した時、Viewに通知する
            _progressModel.DownloadProgress.Subscribe(_progressView.DisplayProgress);
        }
    }
}