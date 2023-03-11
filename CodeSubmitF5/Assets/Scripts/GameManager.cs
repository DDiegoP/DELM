using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    private int credits = 0;
    public int Credits{
        get{
            return credits;
        }
        set{
            credits = value;
        }
    }
    
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

    List<Algorythm> unlockedAlgorythms;
    List<Language> unlockedLanguages;
    List<Structure> unlockedStructures;

    private ProblemConstructor problemConstructor;


    List<Problem> problems;
    Problem currentProblem;
    // private ProblemConstructor pconstructor;
    /*[SerializeField]
    private ProblemHolder holder;
    [SerializeField]
    private CalificationTable table;*/
    public static GameManager GetInstance() { return instance; }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }

        LoadJSON();
        problems = new List<Problem>();
        problemConstructor= new ProblemConstructor();
        
    }

    void Start()
    {
        unlockedAlgorythms = new List<Algorythm>();
        unlockedAlgorythms.Add(AlgorythmList[0]);
        unlockedLanguages = new List<Language>();
        unlockedLanguages.Add(LangList[0]);
        unlockedLanguages.Add(LangList[1]);
        unlockedStructures = new List<Structure>();
        unlockedStructures.Add(StructureList[0]);
    }

    public void TakeDamage(int damage){
        if(HealthBar == null) return;
        HealthBar.GetComponent<HealthScript>().TakeDamage(damage);
        if(HealthBar.GetComponent<HealthScript>().curHealth <= 0){
            //Game over
        }
    }

    public void AddScore(int score){
        if (this.score == null) return;
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

    public void SetProblems(Problem[] problems) => this.problems.AddRange(problems);
    public Problem GenerateRandomProblem()
    {
        return null;
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

    public List<Problem> GetProblems()
    {
        return problems;
    }

    public List<Algorythm> GetUnlockedAlgorythms()
    {
        return unlockedAlgorythms;
    }
    public List<Language> GetUnlockedLanguages()
    {
        return unlockedLanguages;
    }
    public List<Structure> GetUnlockedStructures()
    {
        return unlockedStructures;
    }

    public void SubmitAlgorythm(Algorythm a)
    {
        Debug.Log(a);
        //currentProblem.SubmitAlgorythm(a);
    }
    public void SubmitLanguage(Language l)
    {
        Debug.Log(l);
        //currentProblem.SubmitLanguage(l);
    }
    public void SubmitStructure(Structure s)
    {
        Debug.Log(s);
        //currentProblem.SubmitStructure(s);
    }

}
