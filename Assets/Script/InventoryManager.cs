using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> items = new();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item, int amount)
    {
        InventoryItem existing =
            items.Find(x => x.itemData == item);

        if (existing != null && item.stackable)
        {
            existing.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem(item, amount));
        }
    }
}