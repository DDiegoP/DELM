using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JSONProcessor : MonoBehaviour
{
    GameManager gameManager;

    Proffessor[] ProfsList;
    Language[] LangList;
    Structure[] StructureList;
    Algorythm[] AlgorythmList;

    List<Proffessor> lockedProfs = new List<Proffessor>();
    List<Language> lockedLangs = new List<Language>();
    List<Structure> lockedStructs = new List<Structure>();
    List<Algorythm> lockedAlgs = new List<Algorythm>();




    // Start is called before the first frame update
    void Start()
    {
        gameManager= GameManager.GetInstance();

        ProfsList=(gameManager.GetProfessors());
        LangList=(gameManager.GetLanguages());
        StructureList = (gameManager.GetStructures());
        AlgorythmList = (gameManager.GetAlgorythms());

        foreach (Proffessor p in ProfsList)
        {
            if (!p.unlocked)
                lockedProfs.Add(p);
        }
        foreach (Language l in LangList)
        {
            if (!l.unlocked)
                lockedLangs.Add(l);
        }
        foreach (Structure s in StructureList)
        {
            if (!s.unlocked)
                lockedStructs.Add(s);
        }
        foreach (Algorythm a in AlgorythmList)
        {
            if (!a.unlocked)
                lockedAlgs.Add(a);
        }
        Debug.Log(getRandElem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool QuedanElementos(){
        return !(lockedProfs.Count == 0 && lockedAlgs.Count == 0 && lockedStructs.Count == 0 && lockedLangs.Count == 0);
    }

    public bool getRandElem() //Esto deja ya desbloqueado el componente que toca. Devuelve false si no quedan elementos.
    {
        if(!this.QuedanElementos()) return false;
        while (true)
        {
            int choice = Random.Range(0, 4);
            switch (choice)
            {
                case 0:
                    if (lockedProfs.Count != 0)
                    {
                        int index = Random.Range(0, lockedProfs.Count);
                        Console.log(lockedProfs[index].name);
                        lockedProfs[index].unlocked = true;
                        gameManager.unlockedProffessors.Add(lockedProfs[index]);
                        lockedProfs.RemoveAt(index);
                        return true;
                    }
                    break;
                case 1:
                    if (lockedLangs.Count != 0)
                    {
                        int index = Random.Range(0, lockedLangs.Count);
                        Console.log(lockedLangs[index].name);
                        lockedLangs[index].unlocked = true;
                        gameManager.unlockedLanguages.Add(lockedLangs[index]);                        
                        lockedLangs.RemoveAt(index);
                        return true;
                    }
                    break;
                case 2:
                    if (lockedStructs.Count != 0)
                    {
                        int index = Random.Range(0, lockedStructs.Count);
                        Console.log(lockedStructs[index].name);
                        lockedStructs[index].unlocked = true;
                        gameManager.unlockedStructures.Add(lockedStructs[index]);
                        lockedStructs.RemoveAt(index);
                        return true;
                    }
                    break;
                case 3:
                    if (lockedAlgs.Count != 0)
                    {
                        int index = Random.Range(0, lockedAlgs.Count);
                        lockedAlgs[index].unlocked = true;
                        Console.log(lockedAlgs[index].name);
                        gameManager.unlockedAlgorythms.Add(lockedAlgs[index]);
                        lockedAlgs.RemoveAt(index);
                        return true;
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
