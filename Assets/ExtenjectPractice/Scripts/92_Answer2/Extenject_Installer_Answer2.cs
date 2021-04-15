using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Answer2
{
    public class Extenject_Installer_Answer2 : MonoInstaller
    {
        [SerializeField]
        private Extenject_View_Answer2 _view;

        public override void InstallBindings()
        {
            Container.Bind<Extenject_Model_Answer2>().AsCached();
            // こちらでもよい
            // Container.Bind(typeof(Extenject_Model_Answer2)).AsCached();
            Container.BindInstance(_view).AsCached();
        }
    }
}