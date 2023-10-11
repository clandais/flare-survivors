using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace FlareSurvivors.GameLifetime.Messaging.Messages
{
    public struct LoadSceneResponse
    {
        public bool IsSuccess { get; set; }
        public AsyncOperationHandle<SceneInstance> Handle { get; set; }
    }
}
