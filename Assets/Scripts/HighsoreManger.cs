using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighsoreManger : MonoBehaviour
{
    public GameObject highsoreBoard;
    private TextMeshProUGUI[] alleTexte;

    //public StartManager startManager;
 

    // Start is called before the first frame update
    void Start()
    {
        FillHighsoreTable();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void FillHighsoreTable()
    {
        PlayerScore ps = new PlayerScore();
        alleTexte = highsoreBoard.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI at in alleTexte)
        {
            switch (at.name)
            {
                case "TextRangName1 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(1, out ps);
                        at.text =  ps.Name;
                        break;
                    }
                case "TextRangScore1 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(1, out ps);
                        at.text = ps.Score.ToString();                        
                        break;
                    }
                case "TextRangName2 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(2, out ps);
                        at.text = ps.Name;
                        break;
                    }
                case "TextRangScore2 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(2, out ps);
                        at.text = ps.Score.ToString();
                        break;
                    }
                case "TextRangName3 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(3, out ps);
                        at.text = ps.Name;
                        break;
                    }
                case "TextRangScore3 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(3, out ps);
                        at.text = ps.Score.ToString();
                        break;
                    }
                case "TextRangName4 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(4, out ps);
                        at.text = ps.Name;
                        break;
                    }
                case "TextRangScore4 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(4, out ps);
                        at.text = ps.Score.ToString();
                        break;
                    }
                case "TextRangName5 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(5, out ps);
                        at.text = ps.Name;
                        break;
                    }
                case "TextRangScore5 (TMP)":
                    {
                        StartManager.instance.highscoreTable.TryGetValue(5, out ps);
                        at.text = ps.Score.ToString();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
