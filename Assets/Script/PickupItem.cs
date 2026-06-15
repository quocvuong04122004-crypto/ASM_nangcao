using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount = 1;

    public void Collect()
    {
        Debug.Log("Collect được gọi");

        Debug.Log("InventoryManager: " + InventoryManager.Instance);

        InventoryManager.Instance.AddItem(itemData, amount);

        Destroy(gameObject);
    }
}