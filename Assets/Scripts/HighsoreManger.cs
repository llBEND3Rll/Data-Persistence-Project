using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HighsoreManger : MonoBehaviour
{
    public GameObject highsoreBoard;
    public GameObject inputField;
    private TextMeshProUGUI[] alleTexte;
    private PlayerScore ps;
    private int newPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        ps = new PlayerScore();
        FillHighsoreTable();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartManager.instance.topScore)
        {
            CheckScoreBoardPos(StartManager.instance.newScore);
            StartManager.instance.topScore = false;
        }
    }

    public void FillHighsoreTable()
    {
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

    private void CheckScoreBoardPos(int lastScore)
    {
        bool posFound = false;
        int posNr = 0;
        PlayerScore[] psArrNew = new PlayerScore[6];
        for (int i = 0; i < 6; i++)
        {
            psArrNew[i] = new PlayerScore();
            psArrNew[i].Name = "";
            psArrNew[i].Score = 0;
        }
        PlayerScore[] psArr = new PlayerScore[6];
        int count = StartManager.instance.highscoreTable.Count;
        for (int i = 0; i < count; i++)
        {
            psArr[i] = StartManager.instance.highscoreTable[i+1];
            if (psArr[i].Score < lastScore && !posFound)
            {
                posFound = true;
                posNr = i;
            }
        }
        psArrNew = CopyNewHighsore(posNr, psArr);
        psArrNew[posNr].Score = lastScore;
        psArrNew[posNr].Name = "";
        SortHighsoreTable(psArrNew);
        FillHighsoreTable();
        InputNewName(posNr);
    }

    private PlayerScore[] CopyNewHighsore(int pos, PlayerScore[] oldList)
    {
        PlayerScore[] newList = new PlayerScore[6];
        for (int i = 0; i < 6; i++)
        {
            newList[i] = new PlayerScore();
        }
        for (int i = 0; i < 5; i++)
        {
            if (i < pos)
            {
                newList[i].Name = oldList[i].Name;
                newList[i].Score = oldList[i].Score;
            }
            else
            {
                newList[i+1].Name = oldList[i].Name;
                newList[i+1].Score = oldList[i].Score;
            }
                                    
        }
        return newList;
    }

    private void InputNewName(int pos)
    {
        inputField.SetActive(true);
        newPos = pos;
    }

    public void InputNewSign()
    {
        TMP_InputField tmpInput = inputField.GetComponent<TMP_InputField>();
        if (tmpInput.text.Length > 10)
        {
            tmpInput.text = tmpInput.text.Remove(10);
        }
        StartManager.instance.highscoreTable[newPos+1].Name = tmpInput.text;
        FillHighsoreTable();
    }

    public void InputNewSignEnd()
    {
        inputField.SetActive(false);
    }
    
    private void SortHighsoreTable(PlayerScore[] newData)
    {       
        for (int i = 0; i < 5; i++)
        {
            StartManager.instance.highscoreTable[i + 1].Name = newData[i].Name;
            StartManager.instance.highscoreTable[i + 1].Score  = newData[i].Score;
        }
    }

    public void SaveHighsore()
    {
        Debug.Log("vor dem Speichern");
        StartManager.instance.SaveHighscore();
        Debug.Log("nach dem Speichern");
    }
}
