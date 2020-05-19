using UnityEngine;
using System.Runtime.Serialization.Json;
using System.IO;
using System;
using System.Runtime.Serialization;

/// <summary>
/// Singleton.
/// Хранит информацию о прогрессе пользователя.
/// </summary>
[DataContract]
public class Progress
{
    // Расположение файла для сериализации.
    public static string path = "Progress.json";

    // Единтсвенный объект класса.
    private static Progress instance;

    // Текущий уровень.
    [DataMember]
    public int CurrentLevel { get; set; } = 1;

    // Количество уровней.
    [DataMember]
    public int LevelAmount { get; set; } = 3;

    // Пройдены ли правила.
    [DataMember]
    public bool EndRule { get; set; }

    private Progress() { }

    // Реализация Singleton.
    public static Progress GetInstance()
    {
        if (instance == null)
            instance = new Progress();
        return instance;
    }

    /// <summary>
    /// Сериализует объект.
    /// </summary>
    public static void Serialize()
    {
        try
        {
            var formater = new DataContractJsonSerializer(typeof(Progress));
            using (var fs = new FileStream(path, FileMode.Create))
                formater.WriteObject(fs, GetInstance());
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Десериализует объект.
    /// </summary>
    public static void Deserialize()
    {
        try
        {
            var formater = new DataContractJsonSerializer(typeof(Progress));
            using (var fs = new FileStream(path, FileMode.Open))
                instance = (Progress)formater.ReadObject(fs);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
