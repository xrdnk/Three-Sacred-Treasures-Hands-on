using System;
using System.Collections.Generic;
using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = nameof(BGMData), menuName = "DQEmulation/" + nameof(BGMData))]
    public class BGMData : ScriptableObject, IAudioData
    {
        [SerializeField]
        private List<AudioEntity> _audioEntities = default;

        [SerializeField]
        private float _volume = 0.1f;

        public List<AudioEntity> AudioEntities => _audioEntities;
        public float Volume => _volume;
    }

    [Serializable]
    public class AudioEntity
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private AudioClip _clip;

        public string Name => _name;
        public AudioClip Clip => _clip;
    }

    public interface IAudioData
    {
        List<AudioEntity> AudioEntities { get; }
        float Volume { get; }
    }
}