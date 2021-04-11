using System.Collections.Generic;
using System.Linq;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Service
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMPlayer : MonoBehaviour, IBGMPlayer
    {
        private AudioSource _audioSource;
        private readonly Dictionary<string, int> _NameToIndex = new Dictionary<string, int>();
        private int _CurrentAudioIndex = -1;

        private IBGMRepository _bgmRepository;

        public IReadOnlyReactiveProperty<float> Volume => _volume;
        private IReadOnlyReactiveProperty<float> _volume;

        [Zenject.Inject]
        [VContainer.Inject]
        public void Construct(IBGMRepository bgmRepository)
        {
            _bgmRepository = bgmRepository;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Stop();
            _audioSource.mute = false;
            _audioSource.playOnAwake = false;
            _audioSource.loop = true;
            _audioSource.volume = _bgmRepository.Volume;

            for (var i = 0; i < _bgmRepository.BGMEntities.Count; i++)
            {
                var audioName = _bgmRepository.BGMEntities[i].Name;
                _NameToIndex.Add(audioName, i);
            }

            _volume = _audioSource.ObserveEveryValueChanged(x => x.volume).ToReactiveProperty();
        }

        public void Play(string audioName)
        {
            if (!_NameToIndex.ContainsKey(audioName))
            {
                Debug.LogError("Unable to play because a non-existent audio name was specified.", this);
            }

            Play(_NameToIndex[audioName]);
        }

        public void Play(int audioIndex = 0)
        {
            PlayInternal(audioIndex);
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public void AdjustVolume(float volumeRate)
        {
            _audioSource.volume = volumeRate;
        }

        private void PlayInternal(int audioIndex = 0)
        {
            if (!_bgmRepository.BGMEntities.Any())
            {
                Debug.LogError("Unable to play because no audio entity is set.", this);
                return;
            }

            if (audioIndex < 0 || _bgmRepository.BGMEntities.Count <= audioIndex)
            {
                Debug.LogError("Unable to play because a non-existent index number was specified.", this);
            }

            if (audioIndex == _CurrentAudioIndex)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
            }
            else
            {
                var clip = _bgmRepository.BGMEntities[audioIndex].Clip;
                if(_audioSource.isPlaying) _audioSource.Stop();
                _audioSource.clip = clip;
                _audioSource.Play();
                _CurrentAudioIndex = audioIndex;
            }
        }

    }
}