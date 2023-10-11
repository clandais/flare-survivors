using FlareSurvivors.PlayerLifetime.Messaging.Messages;
using UnityEngine;
using VContainer;

namespace FlareSurvivors.PlayerLifetime.HeroStates
{
    public class HeroStateMove : BaseHeroState
    {
        
        private Vector2 _moveInput;
        public override void Tick()
        {
            _moveInput = InputReader.MoveInput;
            if (_moveInput.magnitude < Mathf.Epsilon)
            {
                StateTransitionPublisher.Publish(new StateTransitionMessage
                {
                    State = Resolver.Resolve<HeroStateIdle>(),
                });
                return;
            }
            
            HeroView.Move(_moveInput);
            
            
        }

        public override void Enter()
        {
            Debug.Log("HeroStateMove");
        }

        public override void Exit()
        {
            
        }
    }
}
