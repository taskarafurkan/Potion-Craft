using PotionCraft.Enum;
using PotionCraft.PotionScripts;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.ItemScripts
{
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
            "Poison",
            ItemType.Ingredient,
            new PotionEffect[] { new Poison() },
            95),

            new Item(1,
            "Blood",
            ItemType.Ingredient,
            new PotionEffect[] { new Heal() },
            80),

            new Item(2,
            "Fire",
            ItemType.Ingredient,
            new PotionEffect[] { new Fire() },
            95),

            new Item(3,
            "Oil",
            ItemType.Ingredient,
            new PotionEffect[] { new Fire(), new Poison() },
            75),

            new Item(4,
            "Milk",
            ItemType.Ingredient,
            new PotionEffect[] { new Power() },
            75),

            new Item(5,
            "Electricity",
            ItemType.Ingredient,
            new PotionEffect[] {new Energy() }
            , 90),

            new Item(6,
            "Sulfur",
            ItemType.Ingredient,
            new PotionEffect[] { new Fire() },
            70),

            new Item(7,
            "Tree",
            ItemType.Ingredient,
            new PotionEffect[] { new Heal() },
            75),

            new Item(8,
            "Virus",
            ItemType.Ingredient,
            new PotionEffect[] { new Poison()},
            90),

            new Item(9,
            "Water",
            ItemType.Ingredient,
            new PotionEffect[] { new Mana()},
            95),

            new Item(10,
            "Ash",
            ItemType.Ingredient,
            new PotionEffect[] { new Fire(), new Poison()},
            50),
        };
        }

        #endregion
    }
}