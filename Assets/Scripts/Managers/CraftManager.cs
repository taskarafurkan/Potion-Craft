using PotionCraft.Enum;
using PotionCraft.InventoryScripts;
using PotionCraft.ItemScripts;
using PotionCraft.PotionScripts;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.Managers
{
    public class CraftManager : MonoBehaviour
    {
        #region Fields
        private List<GameObject> _ingredientsList = new List<GameObject>();
        private List<PotionEffect> _potionEffects = new List<PotionEffect>();

        [SerializeField] private Inventory _inventory;
        [SerializeField] private InventoryUI _inventoryUI;

        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Transform _canvasTransform;

        #endregion

        #region Methods

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<ItemUI>().Item.ItemType == ItemType.Ingredient)
            {
                _ingredientsList.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            else
            {
                int randomDirection = Random.Range(0, 2);

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce
                    (new Vector2(randomDirection == 0 ? Random.Range(-2f, -4f) : Random.Range(2f, 4f), 13), ForceMode2D.Impulse);
            }

            if (_ingredientsList.Count == 2)
            {
                CraftPotion();
            }
        }

        private void CraftPotion()
        {
            Item firstIngredient = _ingredientsList[0].gameObject.GetComponent<ItemUI>().Item;
            Item secondIngredient = _ingredientsList[1].gameObject.GetComponent<ItemUI>().Item;

            //Get effects by probability
            if (Random.Range(0, 100) <= firstIngredient.EffectProbability)
            {
                _potionEffects.AddRange(firstIngredient.PotionEffects);
            }

            if (Random.Range(0, 100) <= secondIngredient.EffectProbability)
            {
                // Check if effect already exist, if exist don't add the list
                foreach (PotionEffect effect in secondIngredient.PotionEffects)
                {
                    if (!_potionEffects.Exists(x => x.GetType() == effect.GetType()))
                    {
                        _potionEffects.Add(effect);
                    }
                }
            }

            // If no effect taken, take greatest probability effect
            if (_potionEffects.Count == 0)
            {
                _potionEffects.AddRange(firstIngredient.EffectProbability > secondIngredient.EffectProbability ? firstIngredient.PotionEffects : secondIngredient.PotionEffects);
            }


            string potionTitle = _potionEffects[0].ToString();

            Item craftedPotion = new Item(potionTitle + " Potion",
                  ItemType.Potion,
                  _potionEffects.Count * 10,
                  _potionEffects.ToArray());


            _inventory.AddItemToInventory(craftedPotion);

            foreach (GameObject ingredient in _ingredientsList)
            {
                Destroy(ingredient);
            }

            _ingredientsList.Clear();

            _potionEffects.Clear();

            CreatePotionGO(craftedPotion);
        }

        private void CreatePotionGO(Item item)
        {
            GameObject gameObject = Instantiate(_itemPrefab, _canvasTransform);
            gameObject.transform.position = transform.position;
            gameObject.transform.localScale = new Vector3(3, 3, 3);

            gameObject.GetComponent<ItemUI>().UpdateItem(item, false);
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    #endregion
}