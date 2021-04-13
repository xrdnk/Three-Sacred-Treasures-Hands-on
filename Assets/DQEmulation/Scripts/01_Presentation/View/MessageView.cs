using UnityEngine;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

namespace Denik.DQEmulation.View
{
    /// <summary>
    /// Debug.Logが処理される際に自動的に表示する
    /// </summary>
    public class MessageView : MonoBehaviour
    {
        [SerializeField]
        private int maxLogCount = 2;
        [SerializeField]
        private Text textMessage = default;

        private readonly Queue<string> _logMessages = new Queue<string>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private void Start()
        {
            textMessage.text = string.Empty;
            Application.logMessageReceived += LogReceived;
        }

        private void LogReceived(string text, string stackTrace, LogType type)
        {
            _logMessages.Enqueue(text);

            while(_logMessages.Count > maxLogCount)
            {
                _logMessages.Dequeue();
            }

            _stringBuilder.Length = 0;
            foreach (var message in _logMessages)
            {
                _stringBuilder.Append(message).Append(System.Environment.NewLine);
            }

            textMessage.text = _stringBuilder.ToString();
        }
    }
}