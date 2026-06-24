using UnityEngine;

public class Tree : MonoBehaviour
{
    private int chopCount = 0;

    public GameObject woodPrefab;

    public void Chop()
    {
        chopCount++;

        Debug.Log("Đã chặt: " + chopCount);

        if (chopCount >= 3)
        {
            Instantiate(
                woodPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(gameObject);
        }
    }
}