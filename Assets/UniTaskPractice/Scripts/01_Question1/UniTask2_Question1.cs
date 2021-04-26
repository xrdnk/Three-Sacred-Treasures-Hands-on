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
            Debug.Log("1秒待ちます．");

            await UniTask.Delay(TimeSpan.FromSeconds(1.0f));

            Debug.Log("1秒経ちました．3秒経過後フラグをtrueにします．");

            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));

            _flag = true;

            await UniTask.WaitUntil(() => _flag);

            Debug.Log("フラグがtrueになりました．");

            return 4.0f;
        }

        private void OnFinished(float time)
        {
            Debug.Log($"{time} 秒経過しました．終了．");
        }
    }
}