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
    // public void AddItem(ItemData item, int amount)
    // {
    //     Debug.Log("AddItem được gọi");

    //     InventoryItem existing =
    //         items.Find(x => x.itemData == item);

    //     if (existing != null && item.stackable)
    //     {
    //         existing.amount += amount;

    //         Debug.Log("Cộng dồn: " + existing.amount);
    //     }
    //     else
    //     {
    //         items.Add(new InventoryItem(item, amount));

    //         Debug.Log("Thêm item mới");
    //     }

    //     Debug.Log("Số item trong inventory: " + items.Count);

    //     foreach (var i in items)
    //     {
    //         Debug.Log(i.itemData.name + " x" + i.amount);
    //     }
    // }

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

        InventoryUI.Instance.Refresh();
        //
        CraftManager.Instance.CheckCraft();
    }
}