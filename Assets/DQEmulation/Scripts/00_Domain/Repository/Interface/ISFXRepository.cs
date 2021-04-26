using System.Collections.Generic;
using Denik.DQEmulation.Entity;

namespace Denik.DQEmulation.Repository
{
    public interface ISFXRepository
    {
        List<SFXEntity> SFXEntities { get; }
        SFXEntity GetSFXEntity(int index);
        float Volume { get; }
    }
}