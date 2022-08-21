using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static StartManager instance;
    public bool topScore;
    public int newScore;

    public Dictionary<int, PlayerScore> highscoreTable;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitHighscoreTable();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void InitHighscoreTable()
    {
        PlayerScore[] psFill = new PlayerScore[5];
        psFill[0] = new PlayerScore();
        psFill[1] = new PlayerScore();
        psFill[2] = new PlayerScore();
        psFill[3] = new PlayerScore();
        psFill[4] = new PlayerScore();
        highscoreTable = new Dictionary<int, PlayerScore>();
        highscoreTable.Add(1, psFill[0]);
        highscoreTable.Add(2, psFill[1]);
        highscoreTable.Add(3, psFill[2]);
        highscoreTable.Add(4, psFill[3]);
        highscoreTable.Add(5, psFill[4]);
    }

    public bool CheckHighsoreList(int score)
    {
        PlayerScore ps;
        highscoreTable.TryGetValue(5, out ps);
        if(ps.Score < score)
        {
            newScore = score;
            topScore = true;
            return true;
        }
        
        return false;
    }

    private void InputPlayerName()
    {
        // Eingabe des Spieler Name
        Debug.Log("Top 5 Ergebniss");
    }

    public void SaveHighscore()
    {
        SaveData sd = new SaveData();
        highscoreTable.TryGetValue(1, out sd.ps1);
        highscoreTable.TryGetValue(2, out sd.ps2);
        highscoreTable.TryGetValue(3, out sd.ps3);
        highscoreTable.TryGetValue(4, out sd.ps4);
        highscoreTable.TryGetValue(5, out sd.ps5);

        SaveData2 sd2 = new SaveData2();
        sd2.name[1] = sd.ps1.Name;
        sd2.score[1] = sd.ps1.Score;
        sd2.name[2] = sd.ps2.Name;
        sd2.score[2] = sd.ps2.Score;
        sd2.name[3] = sd.ps3.Name;
        sd2.score[3] = sd.ps3.Score;
        sd2.name[4] = sd.ps4.Name;
        sd2.score[4] = sd.ps4.Score;
        sd2.name[5] = sd.ps5.Name;
        sd2.score[5] = sd.ps5.Score;

        string json = JsonUtility.ToJson(sd2);
 
        File.WriteAllText(Application.persistentDataPath + "/hs.json", json);
    }

    public void LoadSaveHighscore()
    {
        string path = Application.persistentDataPath + "/hs.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData2 sd2 = JsonUtility.FromJson<SaveData2>(json);
            SaveData sd = new SaveData();
            sd.ps1.Name = sd2.name[1];
            sd.ps1.Score = sd2.score[1];
            sd.ps2.Name = sd2.name[2];
            sd.ps2.Score = sd2.score[2];
            sd.ps3.Name = sd2.name[3];
            sd.ps3.Score = sd2.score[3];
            sd.ps4.Name = sd2.name[4];
            sd.ps4.Score = sd2.score[4];
            sd.ps5.Name = sd2.name[5];
            sd.ps5.Score = sd2.score[5];

            highscoreTable.Remove(1);            
            highscoreTable.Remove(2);
            highscoreTable.Remove(3);
            highscoreTable.Remove(4);
            highscoreTable.Remove(5);

            highscoreTable.Add(1, sd.ps1);
            highscoreTable.Add(2, sd.ps2);
            highscoreTable.Add(3, sd.ps3);
            highscoreTable.Add(4, sd.ps4);
            highscoreTable.Add(5, sd.ps5);
        }
    }
}


