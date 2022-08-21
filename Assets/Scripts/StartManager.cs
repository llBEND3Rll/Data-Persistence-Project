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
        //for (int i = 0; i < 6; i++)
        //{
        //    psFill[i] = new PlayerScore();
        //    highscoreTable.Add(i, psFill[i]);
        //}
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
}


