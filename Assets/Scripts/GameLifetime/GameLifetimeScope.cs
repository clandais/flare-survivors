using FlareSurvivors.GameLifetime.GameStates;
using FlareSurvivors.GameLifetime.Messaging;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using FlareSurvivors.GameLifetime.Utils;
using FlareSurvivors.ScriptableObjectsScripts;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlareSurvivors.GameLifetime
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Dependencies")]
        [SerializeField] private SceneReferences sceneReferences;
        [SerializeField] private CoroutineRunner coroutineRunner;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterMessagePipe(builder);
            RegisterGameStates(builder);
            
            builder.RegisterInstance(sceneReferences);
            builder.RegisterInstance(coroutineRunner);
            
            builder.RegisterEntryPoint<GameEntryPoint>();
        }

        private void RegisterMessagePipe(IContainerBuilder builder)
        {
            MessagePipeOptions options = builder.RegisterMessagePipe(
                options =>
                {
                    options.EnableCaptureStackTrace = true;
                });
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(
                c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            builder
                .RegisterAsyncRequestHandler<
                    LoadSceneRequest,
                    LoadSceneResponse,
                    SceneAssetAsyncLoadingHandler>(options);

            builder.RegisterMessageBroker<GameStateTransitionMessage>(options);
        }
        
        
        private void RegisterGameStates(IContainerBuilder builder)
        {
            builder.Register<GameBootState>(Lifetime.Singleton);
            builder.Register<GamePlayState>(Lifetime.Singleton);
        }
    }
}
