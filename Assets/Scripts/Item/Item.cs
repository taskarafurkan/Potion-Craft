using PotionCraft.Enum;
using PotionCraft.PotionScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PotionCraft.ItemScripts
{
    public class Item
    {
        #region Fields
        private int _id;
        private string _title;
        private string _description;
        private Sprite _sprite;
        private Dictionary<string, int> _stats;
        private List<PotionEffect> _potionEffects;
        private ItemType _itemType;
        private int _price;
        private int _effectProbability;
        #endregion

        #region Properties
        public int Id { get => _id; private set => _id = value; }
        public string Title { get => _title; private set => _title = value; }
        public string Description { get => _description; private set => _description = value; }
        public Sprite Sprite { get => _sprite; private set => _sprite = value; }
        public Dictionary<string, int> Stats { get => _stats; private set => _stats = value; }
        public List<PotionEffect> PotionEffects { get => _potionEffects; private set => _potionEffects = value; }
        public ItemType ItemType { get => _itemType; private set => _itemType = value; }
        public int Price { get => _price; private set => _price = value; }
        public int EffectProbability { get => _effectProbability; private set => _effectProbability = value; }
        #endregion

        public Item(int id, string title, string description, ItemType itemType, Dictionary<string, int> stats)
        {
            Id = id;
            Title = title;
            Description = description;
            Stats = stats;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(int id, string title, string description, ItemType itemType, Dictionary<string, int> stats, PotionEffect[] potionEffects)
        {
            Id = id;
            Title = title;
            Description = description;
            Stats = stats;
            PotionEffects = potionEffects.ToList();
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(string title, string description, ItemType itemType, Dictionary<string, int> stats, PotionEffect[] potionEffects)
        {
            Title = title;
            Description = description;
            Stats = stats;
            PotionEffects = potionEffects.ToList();
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(string title, string description, ItemType itemType, int price, PotionEffect[] potionEffects)
        {
            Title = title;
            Description = description;
            ItemType = itemType;
            Price = price;
            PotionEffects = potionEffects.ToList();
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(string title, ItemType itemType, int price, PotionEffect[] potionEffects)
        {
            Title = title;
            ItemType = itemType;
            Price = price;
            PotionEffects = potionEffects.ToList();
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(int id, string title, string description, ItemType itemType, int price, PotionEffect[] potionEffects)
        {
            Id = id;
            Title = title;
            Description = description;
            ItemType = itemType;
            Price = price;
            PotionEffects = potionEffects.ToList();
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(int id, string title, ItemType itemType, PotionEffect[] potionEffects, int effectProbability)
        {
            Id = id;
            Title = title;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
            PotionEffects = potionEffects.ToList();
            EffectProbability = effectProbability;

        }
    }
}