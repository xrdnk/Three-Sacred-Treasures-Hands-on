using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Answer1
{
    public class Extenject_Installer_Answer : MonoInstaller
    {
        [SerializeField]
        private Extenject_Model_Answer _model;
        [SerializeField]
        private Extenject_View_Answer _view;

        public override void InstallBindings()
        {
            Container.BindInstance(_model).AsCached();
            Container.BindInstance(_view).AsCached();
        }
    }
}