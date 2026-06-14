using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    public static AudioSetting Instance;

    public float CurrentVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            CurrentVolume =
                PlayerPrefs.GetFloat(
                    "MasterVolume",
                    1f
                );

            AudioListener.volume =
                CurrentVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        CurrentVolume = volume;

        AudioListener.volume =
            volume;

        PlayerPrefs.SetFloat(
            "MasterVolume",
            volume
        );

        PlayerPrefs.Save();
    }
}