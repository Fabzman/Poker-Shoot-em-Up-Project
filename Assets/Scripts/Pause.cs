using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unPause()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
