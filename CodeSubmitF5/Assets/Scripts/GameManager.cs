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
    Proffessor[] ProfsList;

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
        ProfsList[0].LoadSprite();
        problemConstructor = new ProblemConstructor();
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

    public Problem GenerateRandomProblem()
    {
        return problemConstructor.generateProblem(Time.time);
    }
}
