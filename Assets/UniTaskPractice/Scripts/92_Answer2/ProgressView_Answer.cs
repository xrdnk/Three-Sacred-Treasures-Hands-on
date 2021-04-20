using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Denik.UniTaskPractice.Answer2
{
    public class ProgressView_Answer : MonoBehaviour
    {
        [SerializeField, Tooltip("ダウンロード進捗率表示用のUI")]
        private Text _text;
        [SerializeField, Tooltip("ダウンロードボタン")]
        private Button _button;

        private IObservable<Unit> _onDownloadButtonPushed => _button.OnClickAsObservable();
        public IObservable<Unit> OnDownloadButtonPushed => _onDownloadButtonPushed;

        /// <summary>
        /// ダウンロード進捗率を整数表示する
        /// </summary>
        /// <param name="progress"></param>
        public void DisplayProgress(float progress)
        {
            _text.text = progress.ToString("F0") + " %";
        }
    }
}