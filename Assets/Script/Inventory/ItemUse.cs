using UnityEngine;
using UnityEngine.InputSystem;

public class ItemUse : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            InventoryManager.Instance.UseSelectedItem();
        }
    }
}