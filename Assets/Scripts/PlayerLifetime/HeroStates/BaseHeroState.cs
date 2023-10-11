using System;
using FlareSurvivors.Core.States;
using FlareSurvivors.Input.Interfaces;
using FlareSurvivors.PlayerLifetime.Messaging.Messages;
using MessagePipe;
using VContainer;

namespace FlareSurvivors.PlayerLifetime.HeroStates
{
    public abstract class BaseHeroState : BaseState
    {
        [Inject] protected IObjectResolver Resolver;
        [Inject] protected IInputReader InputReader;
        [Inject] protected IPublisher<StateTransitionMessage> StateTransitionPublisher;
        [Inject] protected HeroView HeroView;
        

        public override void Dispose()
        {
            Resolver?.Dispose();
        }
    }
}
