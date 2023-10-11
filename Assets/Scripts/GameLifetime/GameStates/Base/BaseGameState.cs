using FlareSurvivors.Core.States;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using FlareSurvivors.GameLifetime.Utils;
using FlareSurvivors.ScriptableObjectsScripts;
using MessagePipe;
using VContainer;

namespace FlareSurvivors.GameLifetime.GameStates.Base
{
    /// <summary>
    ///  Base class for all game states.
    /// </summary>
    public abstract class BaseGameState : BaseState
    {
        [Inject] protected IObjectResolver Resolver;
        [Inject] protected SceneReferences SceneReferences;
        [Inject] protected IAsyncRequestHandler<LoadSceneRequest, LoadSceneResponse> LoadSceneRequestHandler;
        [Inject] protected CoroutineRunner CoroutineRunner;

        public override void Dispose()
        {
            Resolver?.Dispose();
        }
    }
}
