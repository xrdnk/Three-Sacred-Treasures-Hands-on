using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class BGMResourceProvider
    {
        public BGMData BGMData { get; }

        [Zenject.Inject]
        [VContainer.Inject]
        public BGMResourceProvider(BGMData bgmData)
        {
            BGMData = bgmData;
        }
    }
}