using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;

    public int highScore;
    public string bestPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        Instance = this;

        LoadHighScore();
    }

    public void ValidateHighScore(int points)
    {
        if(points > highScore)
        {
            highScore = points;
            bestPlayerName = DataManager.Instance.playerName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayer;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.bestScore = highScore;
        data.bestPlayer = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.bestScore;
            bestPlayerName = data.bestPlayer;
        }
    }
    
}
