using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreHandler.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
