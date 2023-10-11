using Cysharp.Threading.Tasks;
using FlareSurvivors.GameLifetime.GameStates.Base;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace FlareSurvivors.GameLifetime.GameStates
{
    public class GamePlayState : BaseGameState
    {
        
        private AsyncOperationHandle<SceneInstance> _gamePlayScenehandle;
        
        public override async void Enter()
        {
            LoadSceneResponse response = await LoadSceneRequestHandler.InvokeAsync(new LoadSceneRequest
            {
                SceneReference = SceneReferences.GameScene,
            });

            if (!response.IsSuccess)
            {
                Debug.LogError("GamePlayState failed to load GameScene.");
                return;
            }
            
            _gamePlayScenehandle = response.Handle;
            await _gamePlayScenehandle.Result.ActivateAsync();
        }

        public override void Tick()
        {
            
        }

        public override async void Exit()
        {
            await Addressables.UnloadSceneAsync(_gamePlayScenehandle).ToUniTask(CoroutineRunner);
        }
    }
}
