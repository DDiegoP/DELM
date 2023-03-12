using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    private int credits = 100;
    public int Credits{
        get{
            return credits;
        }
        set{
            credits = value;
        }
    }

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

    public List<Algorythm> unlockedAlgorythms;
    public List<Language> unlockedLanguages;
    public List<Structure> unlockedStructures;
    public List<Proffessor> unlockedProffessors;
    public static GameManager GetInstance() { return instance; }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
        
        LoadJSON();
        
        InitializeUnlocked();

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
    }
    public void SubmitLanguage(Language l)
    {
        Debug.Log(l);
    }
    public void SubmitStructure(Structure s)
    {
        Debug.Log(s);
    }

}
