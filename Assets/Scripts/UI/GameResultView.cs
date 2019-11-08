using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class GameResultView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textValue;        
        public Button restartButton;
        public Button mainMenuButton;
        public Button continueButton;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetTextValue(string time)
        {
            textValue.text = time;
        }
    }
}