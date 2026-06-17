using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public static CraftManager Instance;

    public List<CraftRecipe> recipes = new();

    private void Awake()
    {
        Instance = this;
    }

    public void CheckCraft()
    {
        bool crafted = true;

        while (crafted)
        {
            crafted = false;

            foreach (var recipe in recipes)
            {
                if (CanCraft(recipe))
                {
                    ExecuteCraft(recipe);
                    crafted = true;
                    break;
                }
            }
        }
    }

    bool CanCraft(CraftRecipe recipe)
    {
        return Has(recipe.inputA, recipe.amountA)
            && (recipe.inputB == null || Has(recipe.inputB, recipe.amountB));
    }

    bool Has(ItemData item, int amount)
    {
        if (item == null) return true;

        InventoryItem invItem =
            InventoryManager.Instance.items.Find(x => x.itemData == item);

        return invItem != null && invItem.amount >= amount;
    }

    void ExecuteCraft(CraftRecipe recipe)
    {
        Remove(recipe.inputA, recipe.amountA);

        if (recipe.inputB != null)
            Remove(recipe.inputB, recipe.amountB);

        InventoryManager.Instance.AddItem(recipe.output, 1);

        Debug.Log($"Crafted: {recipe.output.itemName}");

        InventoryUI.Instance.Refresh();
    }

    void Remove(ItemData item, int amount)
    {
        if (item == null) return;

        InventoryItem invItem =
            InventoryManager.Instance.items.Find(x => x.itemData == item);

        if (invItem == null) return;

        invItem.amount -= amount;

        if (invItem.amount <= 0)
            InventoryManager.Instance.items.Remove(invItem);
    }
}