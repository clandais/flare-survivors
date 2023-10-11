using Cysharp.Threading.Tasks;
using FlareSurvivors.GameLifetime.GameStates.Base;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace FlareSurvivors.GameLifetime.GameStates
{
    public class GameBootState : BaseGameState
    {
        private AsyncOperationHandle<SceneInstance> _gameBootSceneHandle;

        public override async void Enter()
        {
            LoadSceneResponse response = await LoadSceneRequestHandler.InvokeAsync(new LoadSceneRequest
            {
                SceneReference = SceneReferences.MainMenuScene,
            });

            if (!response.IsSuccess)
            {
                Debug.LogError("GameBootState failed to load GameScene.");
                return;
            }

            _gameBootSceneHandle = response.Handle;
            await _gameBootSceneHandle.Result.ActivateAsync();
        }

        public override void Tick()
        {

        }

        public override async void Exit()
        {
            await Addressables.UnloadSceneAsync(_gameBootSceneHandle).ToUniTask(CoroutineRunner);
        }
    }
}
