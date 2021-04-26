using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public class SFXRepository : ISFXRepository
    {
        private SFXData _sfxData;

        [Zenject.Inject]
        [VContainer.Inject]
        public SFXRepository(SFXData sfxData)
        {
            _sfxData = sfxData;
        }

        public List<SFXEntity> SFXEntities => _sfxData.AudioEntities;

        public SFXEntity GetSFXEntity(int index) => _sfxData.AudioEntities[index];

        public float Volume => _sfxData.Volume;
    }
}