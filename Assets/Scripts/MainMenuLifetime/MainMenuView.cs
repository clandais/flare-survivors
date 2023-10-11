using UnityEngine;
using UnityEngine.UI;

namespace FlareSurvivors.MainMenuLifetime
{
    [AddComponentMenu("Flare Survivors/Main Menu View")]
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        public Button PlayButton => playButton;
    }
}
