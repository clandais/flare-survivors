using System.Threading;
using Cysharp.Threading.Tasks;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using FlareSurvivors.GameLifetime.Utils;
using MessagePipe;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using VContainer;

namespace FlareSurvivors.GameLifetime.Messaging
{
    public class SceneAssetAsyncLoadingHandler 
        : IAsyncRequestHandler<LoadSceneRequest, LoadSceneResponse>
    {
        [Inject] private CoroutineRunner _coroutineRunner;
        
        
        public async UniTask<LoadSceneResponse> InvokeAsync(LoadSceneRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            var handle =
                Addressables.LoadSceneAsync(request.SceneReference.Address, LoadSceneMode.Additive, false);
            await handle.ToUniTask(_coroutineRunner);
            
            return new LoadSceneResponse
            {
                IsSuccess = true,
                Handle = handle,
            };
        }

    }
}
