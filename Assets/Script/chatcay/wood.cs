using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    private bool canPickUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Đã nhặt gỗ");

            Destroy(gameObject);
        }
    }
}