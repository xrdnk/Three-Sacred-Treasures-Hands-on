using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Question2
{
    public class Extenject_Installer_Question2 : MonoInstaller
    {
        [SerializeField]
        private Extenject_View_Question2 _view;

        public override void InstallBindings()
        {
            // Model の Bind を行う

            // View の Bind を行う
            Container.BindInstance(_view).AsCached();
        }
    }
}