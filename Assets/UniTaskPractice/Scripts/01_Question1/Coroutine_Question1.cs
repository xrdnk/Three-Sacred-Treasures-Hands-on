using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Denik.UniTaskPractice.Question1
{
    public class Coroutine_Question1 : MonoBehaviour
    {
        private bool _flag = false;

        private void Start()
        {
            StartCoroutine(HogeCoroutine(OnFinished));
        }

        private IEnumerator HogeCoroutine(UnityAction<float> callback = null)
        {
            Debug.Log("1秒待ちます．");

            yield return new WaitForSeconds(1.0f);

            Debug.Log("1秒経ちました．3秒経過後フラグをtrueにします．");

            yield return new WaitForSeconds(3.0f);

            _flag = true;

            yield return new WaitUntil(() => _flag);

            Debug.Log("フラグがtrueになりました．");

            callback(4.0f);
        }

        private void OnFinished(float time)
        {
            Debug.Log($"{time} 秒経過しました．終了．");
        }
    }
}