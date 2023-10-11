#region
using System;
using FlareSurvivors.Input.Interfaces;
using FlareSurvivors.PlayerLifetime.HeroStates;
using FlareSurvivors.PlayerLifetime.Messaging.Messages;
using MessagePipe;
using VContainer;
using VContainer.Unity;
#endregion

namespace FlareSurvivors.PlayerLifetime
{
    public class HeroEntryPoint :
        IStartable,
        ITickable,
        IDisposable
    {
        [Inject] private ISubscriber<StateTransitionMessage> _stateTransitionSubscriber;

        [Inject] private IInputReader _inputReader;

        [Inject] private HeroView _heroView;

        [Inject] private IObjectResolver _resolver;

        private IDisposable _disposable;
        private BaseHeroState _currentState;

        public void Start()
        {
            
            
            DisposableBagBuilder bag = DisposableBag.CreateBuilder();
            _stateTransitionSubscriber
                .Subscribe(OnStateTransition)
                .AddTo(bag);

            _disposable = bag.Build();

            _currentState = _resolver.Resolve<HeroStateIdle>();
            _currentState.Enter();
        }

        private void OnStateTransition(StateTransitionMessage msg)
        {
            _currentState.Exit();
            _currentState = msg.State;
            _currentState.Enter();
        }

        public void Tick()
        {
            _currentState.Tick();
        }

        public void Dispose()
        {
            _resolver?.Dispose();
            _disposable?.Dispose();
        }
    }
}
