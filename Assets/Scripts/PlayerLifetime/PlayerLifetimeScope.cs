using FlareSurvivors.Input;
using FlareSurvivors.Input.Interfaces;
using FlareSurvivors.PlayerLifetime.HeroStates;
using FlareSurvivors.PlayerLifetime.Messaging.Messages;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlareSurvivors.PlayerLifetime
{
    public class PlayerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            RegisterMessages(builder);
            RegisterPlayerStates(builder);


            builder.Register<IInputReader, InputReader>(Lifetime.Scoped);
            builder.RegisterEntryPoint<HeroEntryPoint>(Lifetime.Scoped);
            builder.RegisterEntryPointExceptionHandler(ex => Debug.LogError($"{ex}"));

            builder.RegisterComponentInHierarchy<HeroView>();
        }

        private void RegisterMessages(IContainerBuilder builder)
        {
            MessagePipeOptions opt = Parent.Container.Resolve<MessagePipeOptions>();
            builder.RegisterMessageBroker<StateTransitionMessage>(opt);
        }

        private void RegisterPlayerStates(IContainerBuilder builder)
        {
            builder.Register<HeroStateIdle>(Lifetime.Scoped);
            builder.Register<HeroStateMove>(Lifetime.Scoped);
        }
    }
}
