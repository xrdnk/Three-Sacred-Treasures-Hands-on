using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class BGMRepository : IBGMRepository
    {
        private BGMData _bgmData;

        [Zenject.Inject]
        [VContainer.Inject]
        public BGMRepository(BGMData bgmData)
        {
            _bgmData = bgmData;
        }

        public List<AudioEntity> BGMEntities => _bgmData.AudioEntities;

        public AudioEntity GetBGMEntity(int index) => _bgmData.AudioEntities[index];

        public float Volume => _bgmData.Volume;
    }
}