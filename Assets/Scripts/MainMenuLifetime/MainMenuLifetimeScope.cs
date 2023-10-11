using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlareSurvivors.MainMenuLifetime
{
    [AddComponentMenu("Flare Survivors/Main Menu Lifetime Scope")]
    public class MainMenuLifetimeScope : LifetimeScope
    {
        [SerializeField] private MainMenuView mainMenuView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(mainMenuView);
            builder.RegisterEntryPoint<MainMenuEntryPoint>();
        }
    }
}
