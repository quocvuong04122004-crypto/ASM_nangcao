using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    public GameObject panel;

    public TMP_Text questionText;

    public Button btnA;
    public Button btnB;
    public Button btnC;
    public Button btnD;


    private PickupItem currentItem;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ShowQuestion(PickupItem item)
    {
        //viết thêm ở đây
        if (item == null)
        {
            Debug.Log("item null");
            return;
        }
        //---
        currentItem = item;

        panel.SetActive(true);

        questionText.text = item.question;

        btnA.GetComponentInChildren<TMP_Text>().text = item.answerA;
        btnB.GetComponentInChildren<TMP_Text>().text = item.answerB;
        btnC.GetComponentInChildren<TMP_Text>().text = item.answerC;
        btnD.GetComponentInChildren<TMP_Text>().text = item.answerD;
    }

    // public void CheckAnswer(int answerIndex)
    // {
    //     if (answerIndex == currentItem.correctAnswer)
    //     {
    //         Debug.Log("Đúng");
    //         currentItem.Collect();
    //     }
    //     else
    //     {
    //         Debug.Log("Sai");
    //     }

    //     panel.SetActive(false);
    // }

    public void CheckAnswer(int answerIndex)
    {
        if (currentItem == null)
        {
            panel.SetActive(false);
            return;
        }

        PickupItem itemToCollect =
            currentItem;

        panel.SetActive(false);

        if (
            answerIndex
            ==
            itemToCollect.correctAnswer
        )
        {
            Debug.Log("Đúng");

            currentItem = null;

            itemToCollect.Collect();
        }
        else
        {
            Debug.Log("Sai");
        }
    }
}