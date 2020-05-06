using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Скрипт для сцены настроек.
/// </summary>
public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    // Массив доступных разрешений.
    Resolution[] resolutions;

    public Dropdown resDrop;

    /// <summary>
    /// Вызывается один раз при загрузке.
    /// </summary>
    void Start()
    {
        // Устанавливаем доступные разрешения в дропдаун.
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution))
                currentResolutionIndex = i;
        }

        resDrop.ClearOptions();
        resDrop.AddOptions(options);

        resDrop.value = currentResolutionIndex;
        resDrop.RefreshShownValue();
    }

    /// <summary>
    /// Изменение громкости аудио.
    /// </summary>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    /// <summary>
    /// Изменение галочки fullscreen.
    /// </summary>
    /// <param name="isFull"></param>
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    /// <summary>
    /// Изменение разрешения.
    /// </summary>
    /// <param name="resIndex"></param>
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
