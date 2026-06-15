using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text amountText;

    public void SetItem(InventoryItem item)
    {

        Debug.Log(item);
        Debug.Log(item.itemData);
        Debug.Log(icon);

        Debug.Log("SetItem chạy: " + item.itemData.name);
        Debug.Log("Icon: " + item.itemData.icon);
        Debug.Log("Amount: " + item.amount);

        icon.sprite = item.itemData.icon;

        // amountText.text =
        //     item.amount > 1 ?
        //     item.amount.ToString() :
        //     "";

        amountText.text = item.amount.ToString();

        icon.enabled = true;
    }

    public void Clear()
    {
        icon.enabled = false;
        amountText.text = "";
    }
}