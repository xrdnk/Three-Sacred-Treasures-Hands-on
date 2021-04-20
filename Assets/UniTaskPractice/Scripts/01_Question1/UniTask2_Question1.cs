using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Denik.UniTaskPractice.Question1
{
    public class UniTask2_Question1 : MonoBehaviour
    {
        private bool _flag = false;

        private async void Start()
        {
            var time = await HogeAsync();
            OnFinished(time);
        }

        private async UniTask<float> HogeAsync()
        {
            // Coroutine のスクリプトを UniTask 2 版にする
            return 0f;
        }

        private void OnFinished(float time)
        {
            Debug.Log($"{time} 秒経過しました．終了．");
        }
    }
}