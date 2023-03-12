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

    public string getRandElem()
    {

        bool elemPicked = false;
        string name = "";
        while (!elemPicked)
        {
            int choice = Random.Range(0, 4);

            switch (choice)
            {
                case 0:
                    if (lockedProfs.Count != 0)
                    {
                        int index = Random.Range(0, lockedProfs.Count);
                        lockedProfs[index].unlocked = true;
                        name = lockedProfs[index].GetName();
                        lockedProfs.RemoveAt(index);
                        elemPicked = true;
                    }
                    break;
                case 1:
                    if (lockedLangs.Count != 0)
                    {
                        int index = Random.Range(0, lockedLangs.Count);
                        lockedLangs[index].unlocked = true;
                        name = lockedLangs[index].GetName();
                        lockedLangs.RemoveAt(index);
                        elemPicked = true;
                    }
                    break;
                case 2:
                    if (lockedStructs.Count != 0)
                    {
                        int index = Random.Range(0, lockedStructs.Count);
                        lockedStructs[index].unlocked = true;
                        name = lockedStructs[index].GetName();
                        lockedStructs.RemoveAt(index);
                        elemPicked = true;
                    }
                    break;
                case 3:
                    if (lockedAlgs.Count != 0)
                    {
                        int index = Random.Range(0, lockedAlgs.Count);
                        lockedAlgs[index].unlocked = true;
                        name = lockedAlgs[index].GetName();
                        lockedAlgs.RemoveAt(index);
                        elemPicked = true;
                    }
                    break;
            }

        }
        return name;
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
