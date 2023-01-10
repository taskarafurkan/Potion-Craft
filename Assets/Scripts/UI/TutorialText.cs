using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PotionCraft.UIScripts
{
    public class TutorialText : MonoBehaviour
    {
        private TextMeshProUGUI tutorialText;

        private void Awake()
        {
            tutorialText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            DOVirtual.DelayedCall(5f, () =>
            {
                tutorialText.DOColor(new Color(1, 1, 1, 0), 1f);
            });
        }
    }
}