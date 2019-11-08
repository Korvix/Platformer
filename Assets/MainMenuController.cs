using Platformer.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class MainMenuController : MonoBehaviour
    {
        private const string ENGLISH = "EN";
        private const string POLISH = "PL";
        private const string LEVEL_1 = "Level_1";
        [SerializeField]
        private Button englishButton;
        [SerializeField]
        private Button polishButton;
        [SerializeField]
        private Button startButton;
        private Localization localization;

        private void Awake()
        {
            localization = Localization.Instance;
            DontDestroyOnLoad(localization);
            englishButton.onClick.AddListener(delegate { localization.SetActualLanguage(ENGLISH); });
            polishButton.onClick.AddListener(delegate { localization.SetActualLanguage(POLISH); });
            startButton.onClick.AddListener(delegate { SceneManager.LoadScene(LEVEL_1); });
        }
    }
}