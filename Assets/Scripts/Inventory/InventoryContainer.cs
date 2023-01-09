using PotionCraft.Enum;
using PotionCraft.ItemScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PotionCraft.InventoryScripts
{
    public class InventoryContainer : MonoBehaviour, IDropHandler
    {
        #region Fields

        [SerializeField] private GameObject _inventorySlotPrefab;
        [SerializeField] private Transform _potionsInventory;
        [SerializeField] private Transform _ingredientsInventory;

        #endregion

        #region Methods

        public void OnDrop(PointerEventData eventData)
        {
            // Get dropped item on item container
            GameObject droppedGO = eventData.pointerDrag;

            if (!droppedGO.GetComponent<ItemUI>())
                return;

            GameObject inventorySlotGO;

            // Check item type and put correct inventory container
            if (droppedGO.GetComponent<ItemUI>().Item.ItemType == ItemType.Potion)
            {
                // Spawn inventory slot when item released on inventory container
                inventorySlotGO = Instantiate(_inventorySlotPrefab, _potionsInventory);
            }
            else
            {
                // Spawn inventory slot when item released on inventory container
                inventorySlotGO = Instantiate(_inventorySlotPrefab, _ingredientsInventory);
            }

            inventorySlotGO.transform.localScale = new Vector3(50, 50, 50);

            droppedGO.transform.SetParent(inventorySlotGO.transform);
        }

        #endregion
    }
}