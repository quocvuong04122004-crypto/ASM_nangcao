using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("Inventory Slots")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotContainer;
    [SerializeField] private int slotCount = 20;

    private List<InventorySlotUI> slots = new();

    private InputSystem_Actions inputActions;
    private bool isOpen;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Inventory.performed += OnInventory;
    }

    private void OnDisable()
    {
        inputActions.Player.Inventory.performed -= OnInventory;
        inputActions.Player.Disable();
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);

        CreateSlots();
        Refresh();
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        ToggleInventory();
    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;

        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void CreateSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObj =
                Instantiate(slotPrefab, slotContainer);

            InventorySlotUI slot =
                slotObj.GetComponent<InventorySlotUI>();

            slots.Add(slot);
        }
    }

    public void Refresh()
    {
        List<InventoryItem> inventory =
            InventoryManager.Instance.items;

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.Count)
            {
                slots[i].SetItem(inventory[i]);
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}