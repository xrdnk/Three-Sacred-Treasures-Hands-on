using UniRx;

namespace Denik.DQEmulation.Service
{
    public interface IBGMPlayer
    {
        void Play(string audioName);
        void Play(int audioIndex);
        void Stop();
        IReadOnlyReactiveProperty<float> Volume { get; }
        void AdjustVolume(float volumeRate);
    }
}