using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public static SceneScript scenes;

    private void Awake()
    {
        scenes = this;
    }

    public void Death()
    {
        SceneManager.LoadScene("Died");
    }

    public void Win()
    {
        SceneManager.LoadScene("Won");
    }

    public void ExitWindow()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
