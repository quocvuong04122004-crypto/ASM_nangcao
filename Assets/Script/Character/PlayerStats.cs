using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("Hunger")]
    public float maxHunger = 100f;
    public float currentHunger = 100f;

    [Header("Drain")]
    public float walkDrain = 1f;
    public float runDrain = 3f;

    private float currentDrain;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        currentHunger -= currentDrain * Time.deltaTime;

        currentHunger = Mathf.Clamp(
            currentHunger,
            0,
            maxHunger);
    }

    public void SetWalking()
    {
        currentDrain = walkDrain;
    }

    public void SetRunning()
    {
        currentDrain = runDrain;
    }

    public void SetIdle()
    {
        currentDrain = 0f;
    }

    public void RestoreHunger(float amount)
    {
        currentHunger += amount;

        currentHunger = Mathf.Clamp(
            currentHunger,
            0,
            maxHunger);
    }
}