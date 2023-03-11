using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private GameObject HealthBar;
    [SerializeField]
    TextAsset ProffessorJSON;

    [SerializeField]
    TextAsset LangJSON;
    Proffessor[] ProfsList;
    Language[] LangList;

    private ProblemConstructor problemConstructor;

    // private ProblemConstructor pconstructor;
    /*[SerializeField]
    private ProblemHolder holder;
    [SerializeField]
    private CalificationTable table;*/

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }

        LoadProffessors();
        LoadLanguages();
        ProfsList[0].LoadSprite();
        problemConstructor = new ProblemConstructor();
        Debug.Log(LangList[0].GetName());
        foreach(char c in LangList[0].GetCommands())
        {
            Debug.Log(c);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage){
        this.HealthBar.GetComponent<HealthScript>().TakeDamage(damage);
        if(this.HealthBar.GetComponent<HealthScript>().curHealth <= 0){
            //Game over
        }
    }

    public void AddScore(int score){
        this.score.GetComponent<ScoreScript>().AddScore(score);
    }


    void LoadProffessors() {
        ProfsList = JsonUtility.FromJson<ProffessorHolder>(ProffessorJSON.text).array;    
    }

    void LoadLanguages()
    {
        LangList = JsonUtility.FromJson<LanguageHolder>(LangJSON.text).GetLanguages();
    }

    public Problem GenerateRandomProblem()
    {
        return problemConstructor.GenerateProblem(Time.time);
    }
}
