using System.Collections.Generic;
using System.Linq;
using Denik.DQEmulation.Entity;
using Denik.DQEmulation.Repository;
using UnityEngine;

namespace Denik.DQEmulation.Service
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMPlayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audioSource;
        private readonly Dictionary<string, int> _NameToIndex = new Dictionary<string, int>();
        private int _CurrentAudioIndex = -1;

        private BGMResourceProvider _bgmResourceProvider;
        private BGMData _bgmData;

        [Zenject.Inject]
        [VContainer.Inject]
        public void Construct(BGMResourceProvider bgmResourceProvider)
        {
            _bgmResourceProvider = bgmResourceProvider;
            _bgmData = _bgmResourceProvider.BGMData;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Stop();
            _audioSource.mute = false;
            _audioSource.playOnAwake = false;
            _audioSource.loop = true;
            _audioSource.volume = _bgmData.Volume;

            for (var i = 0; i < _bgmData.AudioEntities.Count; i++)
            {
                var audioName = _bgmData.AudioEntities[i].Name;
                _NameToIndex.Add(audioName, i);
            }
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

        private void PlayInternal(int audioIndex = 0)
        {
            if (!_bgmData.AudioEntities.Any())
            {
                Debug.LogError("Unable to play because no audio entity is set.", this);
                return;
            }

            if (audioIndex < 0 || _bgmData.AudioEntities.Count <= audioIndex)
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
                var clip = _bgmData.AudioEntities[audioIndex].Clip;
                if(_audioSource.isPlaying) _audioSource.Stop();
                _audioSource.clip = clip;
                _audioSource.Play();
                _CurrentAudioIndex = audioIndex;
            }
        }

    }
}