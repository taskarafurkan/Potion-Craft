using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    #endregion

    public Item(int id, string title, string description, ItemType itemType, Dictionary<string, int> stats)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Sprite = Resources.Load<Sprite>("Art/Sprites/" + title);
        this.Stats = stats;
        this.ItemType = itemType;
    }

    public Item(int id, string title, string description, ItemType itemType, Dictionary<string, int> stats, PotionEffect[] potionEffects)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Sprite = Resources.Load<Sprite>("Art/Sprites/" + title);
        this.Stats = stats;
        this.PotionEffects = potionEffects.ToList();
        this.ItemType = itemType;
    }

    public Item(int id, string title, string description, ItemType itemType, int price, PotionEffect[] potionEffects)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Sprite = Resources.Load<Sprite>("Art/Sprites/" + title);
        this.PotionEffects = PotionEffects.ToList();
        this.ItemType = itemType;
        this.Price = price;
        this.PotionEffects = potionEffects.ToList();
    }
}