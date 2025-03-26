using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = FindObjectOfType<GameManager>();

            if(instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UIManager.Instance.Initialize();
    }

    public Player Player;
    public IndicatorHandler IndicatorHandler;

    public void Save()
    {
        SaveFormat save = new SaveFormat(Player.Stat.Gold, Player.Stat.Speed, Player.Stat.BreakRate, Player.Stat.PatienceDecayRate);

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Data.SAVE_PATH, json);
    }

    public SaveFormat Load()
    {
        string json = File.ReadAllText(Data.SAVE_PATH);

        SaveFormat save = null;

        if (json != null)
            save = JsonUtility.FromJson<SaveFormat>(json);
        return save;
    }

}
