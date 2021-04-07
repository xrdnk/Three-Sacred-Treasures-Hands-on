namespace Denik.DQEmulation.Service
{
    public interface IAudioPlayer
    {
        void Play(string audioName);
        void Play(int audioIndex);
        void Stop();
    }
}