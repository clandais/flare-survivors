using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Eflatun.SceneReference;
using FlareSurvivors.GameLifetime.GameStates;
using FlareSurvivors.GameLifetime.GameStates.Base;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using FlareSurvivors.ScriptableObjectsScripts;
using MessagePipe;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using VContainer;
using VContainer.Unity;

namespace FlareSurvivors.GameLifetime
{
    public class GameEntryPoint : 
        IStartable,
        ITickable,
        IDisposable
    {
        
        [Inject] private IObjectResolver _resolver;
        [Inject] private ISubscriber<GameStateTransitionMessage> _gameStateTransitionSubscriber;
        
        private IDisposable _disposable;
        private BaseGameState _currentState;
        
        public void Start()
        {
            Debug.Log($" {nameof(GameEntryPoint)} started.");
            
            SetupSubscriber();
            
            _currentState = _resolver.Resolve<GameBootState>();
            _currentState.Enter();

        }

        public void Tick()
        {
            _currentState.Tick();
        }
        
        private void OnGameStateTransition(GameStateTransitionMessage msg)
        {
            _currentState.Exit();
            _currentState = msg.GameState;
            _currentState.Enter();
        }
        
        private void SetupSubscriber()
        {
            DisposableBagBuilder disposableBag = DisposableBag.CreateBuilder();
            _gameStateTransitionSubscriber
                .Subscribe(OnGameStateTransition)
                .AddTo(disposableBag);
            _disposable = disposableBag.Build();
        }
        
        public void Dispose()
        {
            _resolver?.Dispose();
            _disposable?.Dispose();
        }
    }
}
