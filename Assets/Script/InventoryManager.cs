using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Lưu trữ tên vật phẩm và số lượng
    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddItem(string itemName, int amount)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += amount;
        }
        else
        {
            inventory.Add(itemName, amount);
        }
        
        Debug.Log($"Đã thu thập: {itemName}. Tổng số lượng: {inventory[itemName]}");
    }

    public bool HasItem(string itemName, int requiredAmount)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName] >= requiredAmount;
        }
        return false;
    }

    public void RemoveItem(string itemName, int amount)
    {
        if (inventory.ContainsKey(itemName) && inventory[itemName] >= amount)
        {
            inventory[itemName] -= amount;
        }
    }
}