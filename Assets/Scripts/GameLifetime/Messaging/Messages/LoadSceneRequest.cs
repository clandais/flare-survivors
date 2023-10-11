using Eflatun.SceneReference;

namespace FlareSurvivors.GameLifetime.Messaging.Messages
{
    public struct LoadSceneRequest
    {
        public SceneReference SceneReference { get; set; }
    }
}
