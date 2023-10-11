using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.Serialization;

namespace FlareSurvivors.ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "SceneReferences", menuName = "FlareSurvivors/SceneReferences")]
    public class SceneReferences : ScriptableObject
    {
        [Header("Boot Scenes")]
        
        [SerializeField] private SceneReference mainMenuScene;
        public SceneReference MainMenuScene => mainMenuScene;
        
        [SerializeField] private SceneReference gameScene;
        public SceneReference GameScene => gameScene;
    }
}
