using DG.Tweening;
using PotionCraft.UIScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PotionCraft.ItemScripts
{
    public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        #region Fields
        private Item _item;
        private Image _spriteImage;
        private Tooltip _tooltip;
        private Tween _delayTween;
        private bool _isItemInInventory = true;
        #endregion

        #region Properties
        public Item Item { get => _item; private set => _item = value; }
        public bool IsItemInInventory { private get => _isItemInInventory; set => _isItemInInventory = value; }
        #endregion

        #region Methods

        private void Awake()
        {
            _spriteImage = GetComponent<Image>();
        }

        private void Start()
        {
            _tooltip = transform.root.Find("Tooltip").GetComponent<Tooltip>();
        }

        public void UpdateItem(Item item, bool isItemInInventory = true)
        {
            Item = item;
            _isItemInInventory = isItemInInventory;

            if (Item != null)
            {
                _spriteImage.color = Color.white;
                _spriteImage.sprite = Item.Sprite;
            }
            else
            {
                _spriteImage.color = Color.clear;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsItemInInventory) return;

            // Add delay to tooltip
            _delayTween = DOVirtual.DelayedCall(0.3f, () =>
                 {
                     _tooltip.EnableTooltip(Item);
                 });
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Disable tooltip if mouse exit
            _delayTween.Kill();
            _tooltip.DisableToolTip();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!IsItemInInventory) return;

            _tooltip.TooltipPosition(eventData.position);
        }

        #endregion
    }
}