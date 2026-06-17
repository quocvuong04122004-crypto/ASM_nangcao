using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount = 1;

    [Header("Question")]
    public string question;

    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;

    public int correctAnswer;

    public void Collect()
    {
        InventoryManager.Instance.AddItem(itemData, amount);

        Destroy(gameObject);
    }
}