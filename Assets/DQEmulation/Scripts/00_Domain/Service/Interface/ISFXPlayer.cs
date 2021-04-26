using UniRx;

namespace Denik.DQEmulation.Service
{
    public interface ISFXPlayer
    {
        IReadOnlyReactiveProperty<float> Volume { get; }
        void Play(string audioName);
        void Play(int audioIndex);
        void AdjustVolume(float volumeRate);
    }
}