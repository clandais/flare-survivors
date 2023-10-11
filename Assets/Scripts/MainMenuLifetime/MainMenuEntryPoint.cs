using System;
using FlareSurvivors.GameLifetime.GameStates;
using FlareSurvivors.GameLifetime.Messaging.Messages;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace FlareSurvivors.MainMenuLifetime
{
    public class MainMenuEntryPoint : IStartable, IDisposable
    {
        [Inject] private MainMenuView _mainMenuView;
        [Inject] private IPublisher<GameStateTransitionMessage> _gameStateTransitionPublisher;
        [Inject] private IObjectResolver _resolver;
        
        public void Start()
        {
            _mainMenuView.PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            _gameStateTransitionPublisher.Publish(new GameStateTransitionMessage()
            {
                GameState = _resolver.Resolve<GamePlayState>(),
            });
            
        }

        public void Dispose()
        {
            _mainMenuView.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
            _resolver?.Dispose();
        }
    }
}
