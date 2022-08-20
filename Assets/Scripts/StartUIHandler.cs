using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class StartUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void StartNewGame()
    {
        SceneManager.LoadScene(2);       
    }

    public void ShowHighsoreTable()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowStartUI()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    //public void SaveColorClicked()
    //{
    //    MainManager.Instance.SaveColor();
    //}

    //public void LoadColorClicked()
    //{
    //    MainManager.Instance.LoadColor();
        
    //}
}
