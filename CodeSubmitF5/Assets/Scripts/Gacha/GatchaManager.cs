using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GatchaManager : MonoBehaviour
{

    GameManager gm;
    [SerializeField]
    TMP_Text text;
    private const int COST = 3;
    private const int COST10 = 30;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Tirar(){
        if(text.GetComponent<CreditsGetter>().UseCredits(COST)){
            //Aqui ponemos la animación del gachapon y desbloqueamos.

        }else{
            //No tiene suficiente para tirar
        }
    }

    public void Tirar10(){
        if(text.GetComponent<CreditsGetter>().UseCredits(COST10)){
            for(int i = 0; i < 10; i++){
                //Lo que sea tirar
            }
        }else{
            //No tiene suficiente para tirar
        }
    }
}
