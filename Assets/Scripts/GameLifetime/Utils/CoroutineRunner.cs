using System;
using UnityEngine;

namespace FlareSurvivors.GameLifetime.Utils
{
    [AddComponentMenu("Flare Survivors/Utils/Coroutine Runner")]
    public class CoroutineRunner : MonoBehaviour, IProgress<float>
    {
        public void Report(float value)
        {
            Debug.Log($"Progress: {value}");
        }
    }
}
