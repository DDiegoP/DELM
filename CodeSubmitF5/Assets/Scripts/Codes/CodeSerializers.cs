using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CodeSerializable
{
    public string name;
    public string key;
    public string id;
    public bool unlocked;
    public Command[] commands;
    public int puntos;
}
[System.Serializable]
public class LanguageSerializer
{
    public CodeSerializable[] languages;

    public Language[] GetLanguages()
    {
        Language[] langs= new Language[languages.Length];
        for(int i = 0; i < languages.Length; i++)
        {
            langs[i] = new Language(languages[i].name, languages[i].key, languages[i].puntos);
            langs[i].unlocked = languages[i].unlocked;
            langs[i].SetCommands(languages[i].commands);
            langs[i].id = languages[i].id;
        }
        return langs;
    } 
}

[System.Serializable]
public class AlgorythmSerializer
{
    public CodeSerializable[] algorythms;

    public Algorythm[] GetAlgorytms()
    {
        Algorythm[] algs = new Algorythm[algorythms.Length];
        for (int i = 0; i < algorythms.Length; i++)
        {
            algs[i] = new Algorythm(algorythms[i].name, algorythms[i].key, algorythms[i].puntos);
            algs[i].unlocked = algorythms[i].unlocked;
            algs[i].SetCommands(algorythms[i].commands);
        }
        return algs;
    }
}


[System.Serializable]
public class StructureSerializer
{
    public CodeSerializable[] structures;

    public Structure[] GetStructures()
    {
        Structure[] sts = new Structure[structures.Length];

        for (int i = 0; i < structures.Length; i++)
        {
            sts[i] = new Structure(structures[i].name, structures[i].key, structures[i].puntos);
            sts[i].unlocked = structures[i].unlocked;
            sts[i].SetCommands(structures[i].commands);
        }
        return sts;
    }
}
