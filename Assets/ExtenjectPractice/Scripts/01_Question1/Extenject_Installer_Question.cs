using UnityEngine;
using Zenject;

namespace Denik.ExtenjectPractice.Question1
{
    public class Extenject_Installer_Question : MonoInstaller
    {
        [SerializeField]
        private Extenject_Model_Question _model;
        [SerializeField]
        private Extenject_View_Question _view;

        public override void InstallBindings()
        {
            // 今回，ModelもViewもMonoBehaviourを継承し，Hierarchy上にオブジェクトがあるため，
            // BindInstance を利用して DI するクラスを Bind する


            // NOTE : Installer の設定が完了したら，SceneContextに登録すること．登録して初めて動く．
        }
    }
}