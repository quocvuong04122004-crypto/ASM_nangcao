using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//viết thêm ở đây
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("Inventory Slots")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotContainer;
    [SerializeField] private int slotCount = 20;
    public static InventoryUI Instance;

    private List<InventorySlotUI> slots = new();

    private InputSystem_Actions inputActions;
    private bool isOpen;

    //viết thêm ở đây
    [Header("Build")]
    [SerializeField] private Button buildButton;

    [SerializeField] private GameObject housePrefab;

    [SerializeField] private Transform player;

    [SerializeField] private float buildDistance = 6f;

    private bool houseBuilt = false;



    private void Awake()
    {
        Instance = this;

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
        Debug.Log("Refresh UI");
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
        //viết thêm ở đây
        UpdateBuildButton();
    }


    public bool IsOpen()
    {
        return isOpen;
    }


    //viết thêm ở đây
    private void UpdateBuildButton()
    {
        bool canBuild =
            InventoryManager
            .Instance
            .items
            .Count > 0;

        buildButton.interactable =
            canBuild &&
            !houseBuilt;
    }

    public void SpawnHouse()
    {
        if (houseBuilt)
            return;

        if (
            InventoryManager
            .Instance
            .items
            .Count == 0
        )
            return;

        Vector3 spawnPos =
            player.position +
            player.forward *
            buildDistance;

        RaycastHit hit;

        if (
            Physics.Raycast(
                spawnPos + Vector3.up * 20,
                Vector3.down,
                out hit,
                100
            )
        )
        {
            spawnPos =
                hit.point;
        }

        Instantiate(
            housePrefab,
            spawnPos,
            Quaternion.identity
        );

        houseBuilt = true;

        buildButton.interactable =
            false;

        Debug.Log("Đã xây nhà");
    }
}