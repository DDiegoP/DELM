using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        //GameManager.SetActive(true);
        SceneManager.LoadScene("Prueba");
    }

    public void StartGacha()
    {
        //GameManager.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

    //Cierra el juego
    public void Quit()
    {
        Application.Quit();
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
