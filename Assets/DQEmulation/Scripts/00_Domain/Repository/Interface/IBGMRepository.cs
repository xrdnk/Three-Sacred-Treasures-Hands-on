using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public interface IBGMRepository
    {
        List<BGMEntity> BGMEntities { get; }
        BGMEntity GetBGMEntity(int index);
        float Volume { get; }
    }
}