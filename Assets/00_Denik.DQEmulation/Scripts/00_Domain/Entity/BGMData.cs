using System;
using System.Collections.Generic;
using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = nameof(BGMData), menuName = "DQEmulation/" + nameof(BGMData))]
    public class BGMData : ScriptableObject, IAudioData
    {
        [SerializeField]
        private List<BGMEntity> _audioEntities = default;

        [SerializeField]
        private float _volume = 0.1f;

        public List<BGMEntity> AudioEntities => _audioEntities;
        public float Volume => _volume;
    }

    [Serializable]
    public class BGMEntity : IAudioEntity
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private AudioClip _clip;

        public string Name => _name;
        public AudioClip Clip => _clip;
    }
}