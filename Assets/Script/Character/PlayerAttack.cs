using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 3f;
    public LayerMask animalLayer;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
        }
    }

    private void Attack()
{
    Collider[] hits = Physics.OverlapSphere(
        transform.position,
        attackRange,
        animalLayer
    );

    foreach (Collider hit in hits)
    {
        Animal animal = hit.GetComponent<Animal>();

        if (animal != null)
        {
            animal.TakeDamage();
            break;
        }
    }
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}