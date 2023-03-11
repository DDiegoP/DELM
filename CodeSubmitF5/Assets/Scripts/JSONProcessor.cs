using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONProcessor : MonoBehaviour
{
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

    List<Proffessor> lockedProfs;
    List<Language> lockedLangs;
    List<Structure> lockedStructs;
    List<Algorythm> lockedAlgs;

    Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        LoadJSON();
        foreach(Proffessor p in ProfsList){
            if(!p.unlocked)
            lockedProfs.Add(p);
        }
        foreach(Language l in LangList){
            if(!l.unlocked)
            lockedProfs.Add(l);
        }
        foreach(Structure s in StructureList){
            if(!s.unlocked)
            lockedProfs.Add(s);
        }
        foreach(Algorythm a in AlgorythmList){
            if(!a.unlocked)
            lockedProfs.Add(a);
        }
        Debug.Log(getRandElem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadJSON()
    {
        ProfsList = JsonUtility.FromJson<ProffessorHolder>(ProffessorJSON.text).array;  
        LangList = JsonUtility.FromJson<LanguageSerializer>(LangJSON.text).GetLanguages();
        StructureList = JsonUtility.FromJson<StructureSerializer>(StructJSON.text).GetStructures();
        AlgorythmList = JsonUtility.FromJson<AlgorythmSerializer>(AlgJSON.text).GetAlgorytms();

    }

    public string getRandElem(){

        bool elemPicked=false;
        while(!elemPicked){
            int choice= rnd.Next(4);

            switch (choice)
            {
                case 0:
                if(lockedProfs.Count!=0){
                    int index=rnd.Next(lockedProfs.Count);
                    lockedProfs[index].unlocked=true;
                    return lockedProfs[index].getName();
                }
                break;
                case 1:
                if(lockedLangs.Count!=0){
                    int index=rnd.Next(lockedLangs.Count);
                    lockedLangs[index].unlocked=true;
                    return lockedLangs[index].getName();
                }
                break;
                case 2:
                if(lockedStructs.Count!=0){
                    int index=rnd.Next(lockedStructs.Count);
                    lockedStructs[index].unlocked=true;
                    return lockedStructs[index].getName();
                }
                break;
                case 3:
                if(lockedAlgs.Count!=0){
                    int index=rnd.Next(lockedAlgs.Count);
                    lockedAlgs[index].unlocked=true;
                    return lockedAlgs[index].getName();
                }
                break;
            }
        }
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
