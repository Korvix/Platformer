using Platformer.Gameplay;
using UnityEngine;

namespace Platformer.GameSystem
{
    public class GameContext : Singleton<GameContext>
    {
        private InputData inputData;
        private GameRule gameRule;
        private GameCondition gameCondition;
        private UIContext uiContext;
        private Localization localization;
        public InputData InputData { get => inputData; }
        public GameRule GameRule { get => gameRule; }
        public GameCondition GameCondition { get => gameCondition; }
        public UIContext UIContext { get => uiContext; }

        private void Awake()
        {
            inputData = new InputData();
            gameObject.AddComponent<InputSystem>();
            uiContext = new UIContext();
            gameRule = new GameRule();
            gameCondition = new GameCondition();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameCondition.Reset();
            }
        }
    }
}