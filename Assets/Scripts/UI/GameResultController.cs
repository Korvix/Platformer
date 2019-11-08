using Platformer.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    public class GameResultController
    {
        private const string GAME_RESULT_VIEW_PATH = "Views/GameResultView";
        private const string TIME_TEXT = "{0}s";
        private const string TIME_FORMAT = "0.00";
        private const string VIEW_ANIMATION_TRIGGER = "StartPopup";
        private GameResultView gameResultView;
        private Animator gameResultViewAnimator;

        private void Initialize()
        {
            GameObject loadedObject = Resources.Load<GameObject>(GAME_RESULT_VIEW_PATH);
            gameResultView = GameObject.Instantiate(loadedObject).GetComponent<GameResultView>();
            gameResultViewAnimator = gameResultView.GetComponent<Animator>();
            AddListenersToButtons();
        }

        public void ShowEndScreen(float time)
        {
            if (!gameResultView)
            {
                Initialize();
            }
            gameResultView.gameObject.SetActive(true);
            gameResultView.SetTextValue(string.Format(TIME_TEXT, time.ToString(TIME_FORMAT)));
            gameResultViewAnimator.SetTrigger(VIEW_ANIMATION_TRIGGER);
        }

        public void HideEndScreen()
        {
            gameResultView.gameObject.SetActive(false);
        }

        private void AddListenersToButtons()
        {
            gameResultView.restartButton.onClick.AddListener(delegate { RestartAction(); });
            gameResultView.mainMenuButton.onClick.AddListener(delegate { MainMenuAction(); });
        }

        private void RestartAction()
        {
            GameContext.Instance.GameCondition.Reset();
            HideEndScreen();
        }

        private void MainMenuAction()
        {
            HideEndScreen();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
