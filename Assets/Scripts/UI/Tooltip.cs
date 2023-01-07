using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    #region Fields
    private Camera _camera;
    private Image _image;
    private TextMeshProUGUI _toolTipText;
    private RectTransform _rectTransform;
    #endregion

    #region Methods
    private void Awake()
    {
        _camera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
        _toolTipText = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.enabled = false;
    }

    public void DisableToolTip()
    {
        _image.DOColor(Color.clear, 0.1f)
            .OnComplete(() =>
            {
                _image.enabled = false;
                _toolTipText.gameObject.SetActive(false);
            }
       );

        _toolTipText.DOColor(Color.clear, 0.1f);
    }

    public void TooltipPosition(Vector3 mousePos)
    {
        // Convert mouse position to world position
        mousePos.z = Mathf.Abs(_camera.transform.position.z);
        transform.position = _camera.ScreenToWorldPoint(mousePos);

        // Adjust pivot so tooltip cannot go out of the screen
        float pivotX = mousePos.x / Screen.width;

        _rectTransform.pivot = new Vector2(pivotX, 1);
    }

    public void EnableTooltip(Item item)
    {
        _image.enabled = true;
        _toolTipText.gameObject.SetActive(true);

        // Set tooltip colors
        _image.DOColor(new Color(0.4056604f, 0.3269062f, 0.2162246f), 0.2f);
        _toolTipText.DOColor(Color.black, 0.2f);

        // Set tooltip texts
        string statText = string.Empty;
        string potionEffectText = "Effects : \n";

        // Get item contents if there any
        if (item.Stats.Count > 0)
        {
            foreach (var stat in item.Stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }

        if (item.PotionEffects.Count > 0)
        {
            foreach (var potionEffect in item.PotionEffects)
            {
                potionEffectText += "- " + potionEffect.GetType() + "\n";
            }
        }

        string tooltipText = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}\n{3}</b>"
            , item.Title, item.Description, statText, potionEffectText);
        _toolTipText.text = tooltipText;


        gameObject.SetActive(true);
    }

    #endregion
}