using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static StartManager instance;
    //public string playerName;
    public int playerScoreInstTest = 111;

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
        PlayerScore ps = new PlayerScore();
        ps.Name = "han";
        ps.Score = 1;
        highscoreTable = new Dictionary<int, PlayerScore>();
        highscoreTable.Add(1, ps);
        highscoreTable.Add(2, ps);
        highscoreTable.Add(3, ps);
        highscoreTable.Add(4, ps);
        highscoreTable.Add(5, ps);
    }

}


