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

    public void AddItem(ItemData item,int amount)
    {
        if (item == null)
        {
            Debug.Log("Item null");

            return;
        }

        InventoryItem existing =
            items.Find(
                x =>
                x != null &&
                x.itemData == item
            );

        if (
            existing != null
            &&
            item.stackable
        )
        {
            existing.amount += amount;
        }
        else
        {
            items.Add(
                new InventoryItem(
                    item,
                    amount
                )
            );
        }

        if (
            InventoryUI.Instance
            != null
        )
        {
            InventoryUI.Instance
            .Refresh();
        }
    }
    public int GetTotalItem()
    {
        int total = 0;

        foreach (
            var item
            in items
        )
        {
            total += item.amount;
        }

        return total;
    }
    public bool HasUpgradeMaterial()
{
    bool hasWood =
        false;

    bool hasStone =
        false;

    foreach (
        var item
        in items
    )
    {
        if (
            item
            ==
            null
            ||
            item.itemData
            ==
            null
        )
        {
            continue;
        }

        if (
            item
            .itemData
            .itemName
            ==
            "Wood"
        )
        {
            hasWood =
                true;
        }

        if (
            item
            .itemData
            .itemName
            ==
            "Stone"
        )
        {
            hasStone =
                true;
        }
    }

    return
        hasWood
        &&
        hasStone;
}
}