using Denik.DQEmulation.Entity;
using UnityEngine;
using Zenject;

namespace Denik.DQEmulation.Installer
{
    [CreateAssetMenu(fileName = nameof(MasterDataInstaller), menuName = "Installers/" + nameof(MasterDataInstaller))]
    public class MasterDataInstaller : ScriptableObjectInstaller<MasterDataInstaller>
    {
        [SerializeField]
        private PlayerData playerData = default;
        [SerializeField]
        private EnemyData enemyData = default;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromInstance(playerData).AsCached();
            Container.Bind<EnemyData>().FromInstance(enemyData).AsCached();
        }
    }
}