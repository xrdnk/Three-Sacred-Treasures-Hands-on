using Denik.DQEmulation.Entity;
using UnityEngine;
using Zenject;

namespace Denik.DQEmulation.Installer
{
    [CreateAssetMenu(fileName = nameof(MasterDataInstaller), menuName = "Installers/" + nameof(MasterDataInstaller))]
    public class MasterDataInstaller : ScriptableObjectInstaller<MasterDataInstaller>
    {
        [SerializeField]
        private PlayerData _playerData = default;
        [SerializeField]
        private EnemyData _enemyData = default;
        [SerializeField]
        private BGMData bgmData = default;

        [SerializeField] private SFXData _sfxData = default;

        public override void InstallBindings()
        {
            // Entity
            Container.Bind<PlayerData>().FromInstance(_playerData).AsCached();
            Container.Bind<EnemyData>().FromInstance(_enemyData).AsCached();
            Container.Bind<BGMData>().FromInstance(bgmData).AsCached();
            Container.Bind<SFXData>().FromInstance(_sfxData).AsCached();
        }
    }
}