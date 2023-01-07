using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    #region Fields

    private List<Item> _databaseItemsList;

    #endregion

    #region Methods

    private void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItemFromDatabase(int id)
    {
        return _databaseItemsList.Find(item => item.Id == id);
    }

    public Item GetItemFromDatabase(string itemTitle)
    {
        return _databaseItemsList.Find(item => item.Title == itemTitle);
    }

    private void AddItemToDatabase(Item item)
    {
        _databaseItemsList.Add(item);
    }

    private void RemoveItemFromDatabase(Item item)
    {
        _databaseItemsList.Remove(item);
    }

    private void BuildItemDatabase()
    {
        _databaseItemsList = new List<Item>()
        {
            new Item(0,
             "Heal Potion",
             "Gives player some hp",
             ItemType.Potion,
             new Dictionary<string, int>{{ "Price", 30 }},
             new PotionEffect[]{new Heal(), new Poison()})
        };
    }

    #endregion
}