using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField]
    private Slider hungerSlider;

    private void Start()
    {
        hungerSlider.maxValue =
            PlayerStats.Instance.maxHunger;
    }

    private void Update()
    {
        hungerSlider.value =
            PlayerStats.Instance.currentHunger;
    }
}