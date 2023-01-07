using System.Collections.Generic;
using UnityEngine;

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
    }

    private void AddItemToInventory(int id)
    {
        if (_itemDatabase.GetItemFromDatabase(id) == null)
            return;

        Item itemToAdd = _itemDatabase.GetItemFromDatabase(id);
        _inventoryItems.Add(itemToAdd);
        _inventoryUI.AddNewItem(itemToAdd);
    }

    private void AddItemToInventory(string itemTitle)
    {
        if (_itemDatabase.GetItemFromDatabase(itemTitle) == null)
            return;

        Item itemToAdd = _itemDatabase.GetItemFromDatabase(itemTitle);
        _inventoryItems.Add(itemToAdd);
        _inventoryUI.AddNewItem(itemToAdd);
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