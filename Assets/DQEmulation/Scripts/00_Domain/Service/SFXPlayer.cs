using System.Collections.Generic;
using System.Linq;
using Denik.DQEmulation.Repository;
using UniRx;
using UnityEngine;

namespace Denik.DQEmulation.Service
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXPlayer : MonoBehaviour, ISFXPlayer
    {
        private AudioSource _audioSource;
        private readonly Dictionary<string, int> _NameToIndex = new Dictionary<string, int>();
        private int _CurrentAudioIndex = -1;

        private SFXRepository _bgmRepository;

        public IReadOnlyReactiveProperty<float> Volume => _volume;
        private IReadOnlyReactiveProperty<float> _volume;

        [Zenject.Inject]
        [VContainer.Inject]
        public void Construct(SFXRepository sfxRepository)
        {
            _bgmRepository = sfxRepository;
            TryGetComponent(out _audioSource);
            _audioSource.Stop();
            (_audioSource.mute, _audioSource.playOnAwake, _audioSource.loop, _audioSource.volume)
                = (false, false, true, _bgmRepository.Volume);

            for (var i = 0; i < _bgmRepository.SFXEntities.Count; i++)
            {
                var audioName = _bgmRepository.SFXEntities[i].Name;
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
            if (!_bgmRepository.SFXEntities.Any())
            {
                Debug.LogError("Unable to play because no audio entity is set.", this);
                return;
            }

            if (audioIndex < 0 || _bgmRepository.SFXEntities.Count <= audioIndex)
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
                var clip = _bgmRepository.SFXEntities[audioIndex].Clip;
                if(_audioSource.isPlaying) _audioSource.Stop();
                _audioSource.clip = clip;
                _audioSource.PlayOneShot(clip);
                _CurrentAudioIndex = audioIndex;
            }
        }
    }
}