using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class StartMenu : MonoBehaviour
{
    AudioSource audioData;
    public void StartGame()
    {
        //GameManager.SetActive(true);
        SceneManager.LoadScene("MainScene");
        audioData.Play(0);
    }

    public void StartGacha()
    {
        //GameManager.SetActive(true);
        SceneManager.LoadScene("Profepon");
        audioData.Play(0);
    }

    //Cierra el juego
    public void Quit()
    {
        audioData.Play(0);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying= false;
#endif
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
