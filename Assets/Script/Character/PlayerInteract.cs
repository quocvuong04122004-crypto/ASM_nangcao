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

        // inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        // inputActions.Player.Interact.performed -= OnInteract;

        inputActions.Disable();
    }

    // private void OnInteract(InputAction.CallbackContext context)
    // {
    //     Debug.Log("E được nhấn");

    //     if (nearbyItems.Count > 0)
    //     {
    //         Debug.Log("Nhặt: " + nearbyItems[0].name);

    //         nearbyItems[0].Collect();
    //     }
    // }

    private void Interact()
    {
        if (nearbyItems.Count > 0)
        {
            QuizManager.Instance.ShowQuestion(
                nearbyItems[0]
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PickupItem item = other.GetComponent<PickupItem>();

        if (item != null)
        {
            nearbyItems.Add(item);

            Debug.Log("Vào vùng nhặt: " + item.name);
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

    // private void Update()
    // {
    //     if (inputActions.Player.Interact.WasPressedThisFrame())
    //     {
    //         Debug.Log("E được nhấn");

    //         if (nearbyItems.Count > 0)
    //         {
    //             Debug.Log("Nhặt: " + nearbyItems[0].name);
    //             nearbyItems[0].Collect();
    //         }
    //     }
    // }

    private void Update()
    {
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            Interact();
        }
    }
}