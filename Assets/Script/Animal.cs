using UnityEngine;

public class Animal : MonoBehaviour
{
    public int maxHp = 3;

    private int currentHp;

    public GameObject meatPrefab;
    public int meatAmount = 2;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage()
    {
        currentHp--;

        Debug.Log($"{gameObject.name} còn {currentHp} máu");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        for (int i = 0; i < meatAmount; i++)
        {
            Instantiate(
                meatPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }
}