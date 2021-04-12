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
            // 今回，ModelもViewもMonoBehaviourを継承し，Hierarchy上にオブジェクトがあるため，
            // BindInstance を利用して DI するクラスを Bind する
            Container.BindInstance(_model).AsCached();
            Container.BindInstance(_view).AsCached();
            // NOTE : Installer の設定が完了したら，SceneContextのMonoInstallerに登録すること．登録して初めて動く．
        }
    }
}