using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    AudioSource audioData;
    public void StartGame()
    {
        DontDestroyOnLoad(transform.gameObject);
        //GameManager.SetActive(true);
        SceneManager.LoadScene("Prueba");
        audioData.Play(0);
    }

    public void StartGacha()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        //GameManager.SetActive(true);
        SceneManager.LoadScene("SampleScene");
        audioData.Play(0);
    }

    //Cierra el juego
    public void Quit()
    {
        audioData.Play(0);
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioData=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
