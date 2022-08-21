using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour 
{
    
}

[Serializable]
public class HighscoreTable
{
    public Dictionary<int, PlayerScore> Highscore = new Dictionary<int, PlayerScore>();
    
}

[Serializable]
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

[Serializable]
public class SaveData
{

    public PlayerScore ps1 = new PlayerScore();
    public PlayerScore ps2 = new PlayerScore();
    public PlayerScore ps3 = new PlayerScore();
    public PlayerScore ps4 = new PlayerScore();
    public PlayerScore ps5 = new PlayerScore();
}

[Serializable]
public class SaveData2
{
    public string[] name = new string[6];
    public int[] score = new int[6];
}
public enum SceneList
{
    Start,
    Highsore,
    Main
}


