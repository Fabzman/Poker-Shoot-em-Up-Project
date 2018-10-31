using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Start()
    {

    }

    public void LoadStage(int Stage)
    {
        //GameManager.instance.Restart();
        SceneManager.LoadScene(Stage);
    }

    //public void RestartGame()
    //{
    //    GameManager.instance.Restart();
    //    LoadStage(1);
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
