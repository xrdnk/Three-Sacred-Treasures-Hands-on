using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public interface IBGMRepository
    {
        List<AudioEntity> BGMEntities { get; }
        AudioEntity GetBGMEntity(int index);
        float Volume { get; }
    }
}