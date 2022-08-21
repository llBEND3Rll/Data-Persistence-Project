using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour 
{
    
}

[System.Serializable]
public class HighscoreTable
{
    public Dictionary<int, PlayerScore> Highscore = new Dictionary<int, PlayerScore>();
    
}

public class PlayerScore
{
    public PlayerScore()
    {
        Name = "";
        Score = 0;
    }
    public PlayerScore(string name, int score)
    {
        Name = name;
        Score = score; 
    }

    private string _Name;
    public string Name{ get => _Name; set => _Name = value; }

    private int _Score;
    public int Score { get => _Score; set => _Score = value; }
}

public enum SceneList
{
    Start,
    Highsore,
    Main
}

public struct PlayerScoreTest
{
    string name;
    int score;
}

