using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value =
            AudioSetting.Instance.CurrentVolume;

        slider.onValueChanged
            .AddListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        AudioSetting.Instance
            .SetVolume(value);
    }
}