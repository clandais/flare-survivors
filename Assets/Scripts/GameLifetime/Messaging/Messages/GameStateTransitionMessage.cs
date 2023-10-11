using FlareSurvivors.GameLifetime.GameStates.Base;

namespace FlareSurvivors.GameLifetime.Messaging.Messages
{
    public struct GameStateTransitionMessage
    {
        public BaseGameState GameState { get; set; }
    }
}
