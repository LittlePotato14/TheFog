using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт для загрузки сцен.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Вызывается один раз при загрузке.
    /// </summary>
    void Start()
    {
        // Если существует файл, десериализуем из него прогресс.
        if (File.Exists(Progress.path))
        {
            Progress.Deserialize();
            return;
        }

        // Если файла нет, сериализуем прогресс с начальными установками.
        Progress.Serialize();
    }

    /// <summary>
    /// Загрузка Сцены по имени.
    /// </summary>
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Нажатие на кнопку старта игры.
    /// </summary>
    public void OnStartButton()
    {
        try
        {
            var inst = Progress.GetInstance();

            // Загрузка уровня.
            if (inst.CurrentLevel <= inst.LevelAmount)
                LoadScene("Map" + inst.CurrentLevel);

            // Загрузка экрана окончания игры.
            else
                LoadScene("GameOver");
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
