using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    private List<PickupItem> nearbyItems = new();

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        Debug.Log("PlayerInteract Enable");

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Interact()
    {
        // Xóa các item đã bị Destroy khỏi danh sách
        nearbyItems.RemoveAll(item => item == null);

        if (nearbyItems.Count > 0)
        {
            PickupItem item = nearbyItems[0];

            // Xóa khỏi danh sách trước khi Collect
            nearbyItems.RemoveAt(0);

            Debug.Log("Nhặt: " + item.name);

            item.Collect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PickupItem item = other.GetComponent<PickupItem>();

        if (item != null)
        {
            if (!nearbyItems.Contains(item))
            {
                nearbyItems.Add(item);

                Debug.Log("Vào vùng nhặt: " + item.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickupItem item = other.GetComponent<PickupItem>();

        if (item != null)
        {
            nearbyItems.Remove(item);

            Debug.Log("Ra khỏi vùng nhặt: " + item.name);
        }
    }

    private void Update()
    {
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            Interact();
        }
    }
}