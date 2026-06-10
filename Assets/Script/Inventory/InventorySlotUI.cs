using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text amountText;

    public void SetItem(InventoryItem item)
    {
        icon.sprite = item.itemData.icon;

        amountText.text =
            item.amount > 1 ?
            item.amount.ToString() :
            "";

        icon.enabled = true;
    }

    public void Clear()
    {
        icon.enabled = false;
        amountText.text = "";
    }
}