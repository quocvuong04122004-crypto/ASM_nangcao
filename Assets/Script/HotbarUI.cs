using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> slotImages;

    private int selectedIndex = 0;

    private void Start()
    {
        UpdateSelection();
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            selectedIndex = 0;
            UpdateSelection();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            selectedIndex = 1;
            UpdateSelection();
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            selectedIndex = 2;
            UpdateSelection();
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            selectedIndex = 3;
            UpdateSelection();
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            selectedIndex = 4;
            UpdateSelection();
        }
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < slotImages.Count; i++)
        {
            if (i == selectedIndex)
            {
                slotImages[i].color = Color.yellow;
            }
            else
            {
                slotImages[i].color = Color.white;
            }
        }
    }
}