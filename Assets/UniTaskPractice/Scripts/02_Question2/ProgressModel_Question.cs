using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Denik.UniTaskPractice.Question2
{
    public class ProgressModel_Question : MonoBehaviour
    {
        private ReactiveProperty<float> _downloadProgress = new ReactiveProperty<float>();
        public IReadOnlyReactiveProperty<float> DownloadProgress => _downloadProgress;

        // CancellationTokenの設定
        private CancellationToken _token;

        private void Awake()
        {
            // Destroy時にキャンセルされるCancellationTokenを取得
            _token = this.GetCancellationTokenOnDestroy();
        }

        public async void DownloadContent()
        {
            // 取得したいコンテンツのURL
            var url = "https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.dmg";
            // テキストデータの取得
            var textData = await DownloadTextAsync(url);
            // テキストデータの表示
            Debug.Log(textData);
        }

        /// <summary>
        /// コンテンツのダウンロード処理
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>コンテンツのテキストデータ</returns>
        private async UniTask<string> DownloadTextAsync(string url)
        {
            using var uwr = UnityWebRequest.Get(url);
            // 送受信開始
            await uwr.SendWebRequest()
                // 値の変化を設定
                .ToUniTask(Progress.Create<float>(x => _downloadProgress.Value = x * 100),
                    // cancellationToken: のラベルはつけること
                    cancellationToken: _token);
            // エラーハンドリング
            if (uwr.isNetworkError || uwr.isHttpError) throw new Exception(uwr.error);
            // ダウンロードしたコンテンツのテキストデータを返す
            return uwr.downloadHandler.text;
        }
    }
}