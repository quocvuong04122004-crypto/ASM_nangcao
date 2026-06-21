using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public static PlayerHand Instance;

    [SerializeField] private Transform handHolder;

    private GameObject currentItem;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowItem(GameObject prefab)
    {
        Debug.Log("ShowItem duoc goi");

        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        if (prefab == null)
        {
            Debug.Log("Prefab NULL");
            return;
        }

        Debug.Log("Spawn: " + prefab.name);

        currentItem = Instantiate(prefab, handHolder);

        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.identity;
        currentItem.transform.localScale = Vector3.one;
    }
}