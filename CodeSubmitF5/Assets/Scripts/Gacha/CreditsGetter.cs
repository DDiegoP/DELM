using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreditsGetter : MonoBehaviour
{

    [SerializeField] private TMP_Text creditsText;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        this.gm = GameManager.GetInstance();
        creditsText.text = gm.Credits.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool UseCredits(int c){
        if(c > gm.Credits) return false; //Si no tengo suficientes creditos
        this.gm.Credits -= c;
        creditsText.text = gm.Credits.ToString();
        return true;
    }
}
