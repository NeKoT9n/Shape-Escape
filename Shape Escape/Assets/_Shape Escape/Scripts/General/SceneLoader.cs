using Assets._Shape_Escape.Scripts.General.Constant;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Assets._Shape_Escape.Scripts.General
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadBootScene()
        {
            LoadScene(Constants.SceneNames.BOOT);
        }

        public void LoadGameScene()
        {
            LoadScene(Constants.SceneNames.GAME);
        }

        public void LoadMenuScene()
        {
            LoadScene(Constants.SceneNames.MENU);
        }

        private async void LoadScene(string sceneName)
        {
            await Addressables.LoadSceneAsync(sceneName);
        }
    }
}