using FlareSurvivors.PlayerLifetime.Messaging.Messages;
using UnityEngine;
using VContainer;

namespace FlareSurvivors.PlayerLifetime.HeroStates
{
    public class HeroStateIdle : BaseHeroState
    {
        
        public override void Tick()
        {
            if (InputReader.MoveInput.magnitude > Mathf.Epsilon)
            {
                StateTransitionPublisher.Publish( new StateTransitionMessage
                {
                    State = Resolver.Resolve<HeroStateMove>(),
                });
            }
        }

        public override void Enter()
        {
            HeroView.Idle();
        }

        public override void Exit()
        {
            
        }

        
    }
}
