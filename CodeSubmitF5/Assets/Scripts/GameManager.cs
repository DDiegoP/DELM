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
    private GameObject gameOver;

    [SerializeField]
    private GameObject canvas;

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
    List<Proffessor> unlockedProffessors;

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
        //problemConstructor = new ProblemConstructor();
        InitializeUnlocked();

    }

    void Start()
    {
        
        //unlockedAlgorythms.Add(AlgorythmList[0]);
        //unlockedLanguages = new List<Language>();
        //unlockedLanguages.Add(LangList[0]);
        //unlockedLanguages.Add(LangList[1]);
        //unlockedStructures = new List<Structure>();
        //unlockedStructures.Add(StructureList[0]);
    }

    private void InitializeUnlocked()
    {
        unlockedProffessors = new List<Proffessor>();
        foreach(Proffessor p in ProfsList)
        {
            if(p.unlocked) unlockedProffessors.Add(p);
        }

        unlockedAlgorythms = new List<Algorythm>();
        foreach (Algorythm a in AlgorythmList)
        {
            if (a.unlocked) unlockedAlgorythms.Add(a);
        }

        unlockedStructures = new List<Structure>();
        foreach (Structure s in StructureList)
        {
            if (s.unlocked) unlockedStructures.Add(s);
        }

        unlockedLanguages = new List<Language>();
        foreach (Language l in LangList)
        {
            if (l.unlocked) unlockedLanguages.Add(l);
        }
    }
    
    public void TakeDamage(int damage){
        if(HealthBar == null) return;
        HealthBar.GetComponent<HealthScript>().TakeDamage(damage);
        if(HealthBar.GetComponent<HealthScript>().curHealth <= 0){
            Instantiate(this.gameOver, this.canvas.transform);
            Time.timeScale = 0;
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
    public List<Proffessor> GetUnlockedProfessors()
    {
        return unlockedProffessors;
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
