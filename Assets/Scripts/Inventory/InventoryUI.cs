using PotionCraft.Enum;
using PotionCraft.ItemScripts;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.InventoryScripts
{
    public class InventoryUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<ItemUI> _itemsUI = new List<ItemUI>();
        [SerializeField] private Transform _ingredientInventoryContainer;
        [SerializeField] private Transform _potionInventoryContainer;
        [SerializeField] private GameObject _inventorySlotPrefab;
        [SerializeField] private GameObject _itemPrefab;

        #endregion

        #region Methods

        private void UpdateSlot(int slot, Item item)
        {
            _itemsUI[slot].UpdateItem(item);
        }

        public GameObject GetItem(Item item)
        {
            return _itemsUI.Find(itemUI => itemUI.Item == item).gameObject;
        }

        public void AddNewItemUI(Item item)
        {
            AddInventorySlot(item.ItemType);
            UpdateSlot(_itemsUI.FindIndex(i => i.Item == null), item);
        }
        public void RemoveItem(Item item)
        {
            UpdateSlot(_itemsUI.FindIndex(i => i.Item == item), null);
        }

        public void AddInventorySlot(ItemType itemType)
        {
            GameObject inventorySlotGO = null;

            // Create inventory slot and assign parent by item type
            if (itemType == ItemType.Potion)
            {
                inventorySlotGO = Instantiate(_inventorySlotPrefab,
               _potionInventoryContainer);
            }
            else if (itemType == ItemType.Ingredient)
            {
                inventorySlotGO = Instantiate(_inventorySlotPrefab,
               _ingredientInventoryContainer);
            }

            inventorySlotGO.transform.localScale = new Vector3(50, 50, 50);

            // Create item and assign inventory slot as parent
            Instantiate(_itemPrefab, inventorySlotGO.transform);

            // Add item to list
            _itemsUI.Add(inventorySlotGO.GetComponentInChildren<ItemUI>());
        }

        #endregion
    }
}