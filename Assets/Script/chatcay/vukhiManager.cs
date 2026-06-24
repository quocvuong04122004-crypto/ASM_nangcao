using UnityEngine;

public class AxeHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Tree tree = other.GetComponent<Tree>();

        if (tree != null)
        {
            tree.Chop();
        }
    }
}