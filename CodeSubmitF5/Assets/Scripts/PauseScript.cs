using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField]
    GameObject pauseGame;

    public void Resume(){
        Time.timeScale = 1;
        pauseGame.SetActive(false);
    }

    public void Menu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Pause(){
        pauseGame.SetActive(true);
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
