// using UnityEngine;

// public class PickupItem : MonoBehaviour
// {
//     [SerializeField] private ItemData itemData;
//     [SerializeField] private int amount = 1;

//     [Header("Question")]
//     public string question;

//     public string answerA;
//     public string answerB;
//     public string answerC;
//     public string answerD;

//     public int correctAnswer;

//     public void Collect()
//     {
//         InventoryManager.Instance.AddItem(itemData, amount);

//         Destroy(gameObject);
//     }
// }

using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    [SerializeField]
    private int amount = 1;

    [Header("Question")]
    public string question;

    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;

    public int correctAnswer;

    private bool collected;

    // public void Collect()
    // {
    //     if (collected)
    //     {
    //         Debug.Log("đã nhặt được item");
    //         return;
    //     }

    //     collected = true;
    //     InventoryManager.Instance.AddItem(itemData, amount);
    //     Destroy(gameObject);
    // }
    public void Collect()
    {
        if (collected)
        {
            Debug.Log("đã nhặt được item");
            return;
        }

        if (itemData == null)
        {
            Debug.LogError(
                gameObject.name +
                " itemData NULL"
            );

            return;
        }

        collected = true;

        Debug.Log(
            "Nhặt: "
            +
            itemData.itemName
        );

        InventoryManager
            .Instance
            .AddItem(
                itemData,
                amount
            );

        Destroy(gameObject);
    }

}