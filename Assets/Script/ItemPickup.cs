using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Chuyển dữ liệu sang túi đồ
            InventoryManager.Instance.AddItem(itemInfo.itemName, 1);
            
            // Xóa vật phẩm dưới đất
            Destroy(gameObject);
        }
    }
}