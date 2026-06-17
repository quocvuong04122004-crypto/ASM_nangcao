using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> items = new();

    public int maxSlots = 25;
    public int hotbarSlots = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item, int amount)
    {
        // Nếu stackable thì tìm item đã có
        if (item.stackable)
        {
            InventoryItem existing =
                items.Find(x => x.itemData == item);

            if (existing != null)
            {
                existing.amount += amount;

                RefreshAllUI();
                return;
            }
        }

        // Inventory đầy
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventory Full");
            return;
        }

        // Ưu tiên 5 slot đầu
        if (items.Count < hotbarSlots)
        {
            items.Insert(items.Count,
                new InventoryItem(item, amount));
        }
        else
        {
            items.Add(
                new InventoryItem(item, amount));
        }

        RefreshAllUI();
    }

    private void RefreshAllUI()
    {
        InventoryUI.Instance.Refresh();
        HotbarUI.Instance.Refresh();
    }

    public InventoryItem GetHotbarItem(int index)
    {
        if (index < items.Count)
            return items[index];

        return null;
    }
}