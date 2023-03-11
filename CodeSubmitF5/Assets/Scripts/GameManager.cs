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

    [SerializeField]
    TextAsset StructJSON;

    [SerializeField]
    TextAsset AlgJSON;

    Proffessor[] ProfsList;
    Language[] LangList;
    Structure[] StructureList;
    Algorythm[] AlgorythmList;

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

        LoadJSON();
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

    void LoadJSON()
    {
        ProfsList = JsonUtility.FromJson<ProffessorHolder>(ProffessorJSON.text).array;  
        foreach(Proffessor p in ProfsList)
        {
            p.LoadSprite();
        }
        LangList = JsonUtility.FromJson<LanguageSerializer>(LangJSON.text).GetLanguages();
        StructureList = JsonUtility.FromJson<StructureSerializer>(StructJSON.text).GetStructures();
        AlgorythmList = JsonUtility.FromJson<AlgorythmSerializer>(AlgJSON.text).GetAlgorytms();

    }

    public Problem GenerateRandomProblem()
    {
        return problemConstructor.GenerateProblem(Time.time);
    }

    public Proffessor[] GetProfessors()
    {
        return ProfsList;
    }
    public Structure[] GetStructures()
    {
        return StructureList;
    }
    public Algorythm[] GetAlgorythms()
    {
        return AlgorythmList;
    }
    public Language[] GetLanguages()
    {
        return LangList;
    }
}
