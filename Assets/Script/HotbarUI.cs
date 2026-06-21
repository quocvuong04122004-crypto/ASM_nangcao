using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarUI : MonoBehaviour
{
    public static HotbarUI Instance;
    public int SelectedIndex => selectedIndex;

    [SerializeField]
    private List<InventorySlotUI> hotbarSlots;

    private int selectedIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Refresh();
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectSlot(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectSlot(1);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SelectSlot(2);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SelectSlot(3);
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            SelectSlot(4);
        }
    }

    private void SelectSlot(int index)
    {
        selectedIndex = index;

        Debug.Log($"Da chon slot {selectedIndex + 1}");

        InventoryItem item = GetSelectedItem();

        if (item != null)
        {
            Debug.Log($"Item hien tai: {item.itemData.itemName}");

            PlayerHand.Instance.ShowItem(
                item.itemData.handPrefab
            );
        }
        else
        {
            Debug.Log("Slot rong");

            PlayerHand.Instance.ShowItem(null);
        }

        UpdateSelection();
    }

    public InventoryItem GetSelectedItem()
    {
        return InventoryManager.Instance.GetHotbarItem(selectedIndex);
    }

    public void Refresh()
    {
        var items = InventoryManager.Instance.items;

        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            if (i < items.Count)
                hotbarSlots[i].SetItem(items[i]);
            else
                hotbarSlots[i].Clear();
        }

        UpdateSelection();
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            if (i == selectedIndex)
            {
                hotbarSlots[i]
                    .GetComponent<UnityEngine.UI.Image>()
                    .color = Color.yellow;
            }
            else
            {
                hotbarSlots[i]
                    .GetComponent<UnityEngine.UI.Image>()
                    .color = Color.white;
            }
        }
    }
}