using UniRx;

namespace Denik.DQEmulation.Service
{
    public interface IBGMPlayer
    {
        IReadOnlyReactiveProperty<float> Volume { get; }
        void Play(string audioName);
        void Play(int audioIndex);
        void Stop();
        void AdjustVolume(float volumeRate);
    }
}