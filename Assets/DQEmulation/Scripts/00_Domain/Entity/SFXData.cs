using System;
using System.Collections.Generic;
using UnityEngine;

namespace Denik.DQEmulation.Entity
{
    [CreateAssetMenu(fileName = nameof(SFXData), menuName = "DQEmulation/" + nameof(SFXData))]

    public class SFXData : ScriptableObject
    {
        [SerializeField]
        private List<SFXEntity> _audioEntities = default;

        [SerializeField]
        private float _volume = 0.1f;

        public List<SFXEntity> AudioEntities => _audioEntities;
        public float Volume => _volume;
    }

    [Serializable]
    public class SFXEntity : IAudioEntity
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private AudioClip _clip;

        public string Name => _name;
        public AudioClip Clip => _clip;
    }
}