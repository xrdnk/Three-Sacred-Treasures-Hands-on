using UnityEngine;

namespace Denik.DQEmulation.Extension
{
    public static class DecibelExtension
    {
        private static readonly float kMinDecibel = 80f;

        public static float DecibelToFloat(float decibelValue)
        {
            var floatValue = (decibelValue + kMinDecibel) / kMinDecibel;
            return floatValue * floatValue;
        }

        public static float FloatToDecibel(float floatValue)
        {
            floatValue = Mathf.Sqrt(floatValue);
            var decibelValue = floatValue * kMinDecibel - kMinDecibel;
            return decibelValue;
        }
    }
}