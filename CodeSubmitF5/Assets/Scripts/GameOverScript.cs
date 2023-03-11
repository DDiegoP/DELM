using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class GameOverScript : MonoBehaviour
{

    void Quit(){
        Application.Quit();
    }

    void Menu(){
        SceneManager.LoadScene("MainScene");
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
