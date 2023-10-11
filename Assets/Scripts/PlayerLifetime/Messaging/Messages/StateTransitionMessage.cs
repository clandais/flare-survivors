using FlareSurvivors.PlayerLifetime.HeroStates;

namespace FlareSurvivors.PlayerLifetime.Messaging.Messages
{
    public struct StateTransitionMessage
    {
        public BaseHeroState State { get; set;}
    }
}
