using TMPro;
using UnityEngine;

namespace Platformer.GameSystem
{
    public class LocalizationSolver : MonoBehaviour
    {
        [SerializeField]
        private string id;
        private Localization localization;

        private void Awake()
        {
            localization = Localization.Instance;
            TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
            if (textMesh)
            {
                textMesh.text = localization.GetTranslation(id);
            }
        }
    }
}