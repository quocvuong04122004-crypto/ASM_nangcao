using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//viết thêm ở đây
using UnityEngine.UI;
using TMPro;

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

    //Viết thêm ở đây
    [Header("Build System")]

    [SerializeField]
    private Button buildButton;

    [SerializeField]
    private TMP_Text buildButtonText;

    [SerializeField]
    private GameObject level1House;

    [SerializeField]
    private GameObject level2House;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float buildDistance = 8f;

    private GameObject currentHouse;

    private bool houseCreated;

    private bool houseUpdated;
    private Vector3 selectedPos;

    private bool positionSelected;

    //-----


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
        //viết thêm ở đây
        UpdateBuildButton();
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

        //Viết thêm ở đây
        UpdateBuildButton();
    }

    public bool IsOpen()
    {
        return isOpen;
    }


    //Viết thêm ở đây
    private void UpdateBuildButton()
    {
        int itemCount =
            InventoryManager
            .Instance
            .items
            .Count;

        if (!houseCreated)
        {
            buildButton.interactable =
                itemCount >= 1 &&
                positionSelected;

            buildButtonText.text =
                "Build";
        }

        else if (!houseUpdated)
        {
            buildButton.interactable =
                itemCount >= 2;

            buildButtonText.text =
                "Upgrade";
        }

        else
        {
            buildButton.interactable =
                false;

            buildButtonText.text =
                "Done";
        }
    }

    public void BuildOrUpgrade()
    {
        if (!houseCreated)
        {
            SpawnHouse();
        }
        else
        {
            UpgradeHouse();
        }
    }

    private void SpawnHouse()
    {
        currentHouse =
            Instantiate(
                level1House,
                selectedPos,
                Quaternion.identity
            );

        houseCreated = true;

        positionSelected = false;

        UpdateBuildButton();
    }

    private void UpgradeHouse()
    {
        if (currentHouse == null)
            return;

        Vector3 pos =
            currentHouse.transform.position;

        Destroy(currentHouse);

        currentHouse =
            Instantiate(
                level2House,
                pos,
                Quaternion.identity
            );

        houseUpdated =
            true;

        InventoryManager
            .Instance
            .items
            .Clear();

        Refresh();

        UpdateBuildButton();
    }
    public void SelectBuildPosition()
    {
        if (houseCreated)
            return;

        Ray ray =
            Camera.main
            .ScreenPointToRay(
                Mouse.current
                .position
                .ReadValue()
            );

        RaycastHit hit;

        if (
            Physics.Raycast(
                ray,
                out hit,
                100
            )
        )
        {
            selectedPos =
                hit.point;

            positionSelected =
                true;

            Debug.Log(
                "Đã chọn vị trí"
            );

            UpdateBuildButton();
        }
    }
    private void Update()
    {
        if (
            Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame
        )
        {
            SelectBuildPosition();
        }
    }
}