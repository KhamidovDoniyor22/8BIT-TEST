using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Slider volumeSlider;

    private const string VolumeSavedKey = "MasterVolume";

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        float savedVolume = PlayerPrefs.GetFloat(VolumeSavedKey, 0.5f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log($"Fullscreen set to: {isFullscreen}");
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;

        PlayerPrefs.SetFloat(VolumeSavedKey, value);
        PlayerPrefs.Save();
    }
}