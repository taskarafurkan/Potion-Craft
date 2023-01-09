using PotionCraft.ItemScripts;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        #region Fields

        private List<Item> _inventoryItems = new List<Item>();
        private ItemDatabase _itemDatabase;
        private InventoryUI _inventoryUI;

        #endregion

        #region Methods

        private void Awake()
        {
            _itemDatabase = GetComponent<ItemDatabase>();
            _inventoryUI = GetComponent<InventoryUI>();
        }

        private void Start()
        {
            AddItemToInventory(0);
            AddItemToInventory(0);
            AddItemToInventory(1);
            AddItemToInventory(1);
            AddItemToInventory(2);
            AddItemToInventory(2);
            AddItemToInventory(3);
            AddItemToInventory(3);
            AddItemToInventory(4);
            AddItemToInventory(4);
            AddItemToInventory(5);
            AddItemToInventory(5);
            AddItemToInventory(6);
            AddItemToInventory(6);
            AddItemToInventory(7);
            AddItemToInventory(7);
            AddItemToInventory(8);
            AddItemToInventory(8);
            AddItemToInventory(9);
            AddItemToInventory(9);
            AddItemToInventory(10);
            AddItemToInventory(10);


        }

        public void AddItemToInventoryUI(Item item)
        {
            _inventoryItems.Add(item);
            _inventoryUI.AddNewItemUI(item);
        }

        public void AddItemToInventory(Item item)
        {
            _inventoryItems.Add(item);
        }

        private void AddItemToInventory(int id)
        {
            if (_itemDatabase.GetItemFromDatabase(id) == null)
                return;

            Item itemToAdd = _itemDatabase.GetItemFromDatabase(id);
            _inventoryItems.Add(itemToAdd);
            _inventoryUI.AddNewItemUI(itemToAdd);
        }

        private void AddItemToInventory(string itemTitle)
        {
            if (_itemDatabase.GetItemFromDatabase(itemTitle) == null)
                return;

            Item itemToAdd = _itemDatabase.GetItemFromDatabase(itemTitle);
            _inventoryItems.Add(itemToAdd);
            _inventoryUI.AddNewItemUI(itemToAdd);
        }

        private Item CheckForInventoryItem(int id)
        {
            return _inventoryItems.Find(item => item.Id == id);
        }

        private void RemoveInventoryItem(int id)
        {
            Item itemToRemove = CheckForInventoryItem(id);
            if (itemToRemove != null)
            {
                _inventoryItems.Remove(itemToRemove);
                _inventoryUI.RemoveItem(itemToRemove);
            }
        }

        #endregion
    }
}