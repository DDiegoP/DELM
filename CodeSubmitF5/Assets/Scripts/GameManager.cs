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
    private ProblemHolder problemHolder;

    [SerializeField]
    TextAsset ProffessorJSON;
    Proffessor[] ProfsList;

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
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ProblemSlot slot = problemHolder.GetFirstAvailableSlot();
        slot.gameObject.SetActive(true);
        slot.SetTask(ProfsList[0], ProfsList[0].GetAvailableTasks()[0], "C++", "Back", "BinTree");
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


}
