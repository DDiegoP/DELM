using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreditsGetter : MonoBehaviour
{

    [SerializeField] private TMP_Text creditsText;

    // Start is called before the first frame update
    void Start()
    {
        creditsText.text = GameManager.GetInstance().Credits.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
