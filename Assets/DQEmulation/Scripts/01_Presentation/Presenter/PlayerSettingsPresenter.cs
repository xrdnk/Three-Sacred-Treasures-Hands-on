using System;
using Denik.DQEmulation.Service;
using Denik.DQEmulation.View;
using UniRx;

namespace Denik.DQEmulation.Presenter
{
    public class PlayerSettingsPresenter : Zenject.IInitializable, VContainer.Unity.IStartable, IDisposable
    {
        private BGMPlayer _bgmPlayer;
        private PlayerSettingsView _playerSettingsView;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [Zenject.Inject]
        [VContainer.Inject]
        public PlayerSettingsPresenter(BGMPlayer bgmPlayer, PlayerSettingsView playerSettingsView)
        {
            _bgmPlayer = bgmPlayer;
            _playerSettingsView = playerSettingsView;
        }

        public void Initialize()
        {
            Present();
        }

        public void Start()
        {
            Present();
        }

        private void Present()
        {
            _playerSettingsView.OnSliderMovedAsObservable()
                // .Select(DecibelExtension.FloatToDecibel)
                .Subscribe(_bgmPlayer.AdjustVolume)
                .AddTo(_compositeDisposable);

            _bgmPlayer.Volume
                // .Select(DecibelExtension.DecibelToFloat)
                .Subscribe(_playerSettingsView.AdjustBGMSlider)
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }


    }
}