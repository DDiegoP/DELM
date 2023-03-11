using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings.Switch;

[System.Serializable]
public class CodeSerializable
{
    public string name;
    public string commands;
}
[System.Serializable]
public class LanguageHolder
{
    public CodeSerializable[] languages;

    public Language[] GetLanguages()
    {
        Language[] langs= new Language[languages.Length];
        for(int i = 0; i < languages.Length; i++)
        {
            langs[i] = new Language(languages[i].name);
            foreach(char c in languages[i].commands)
            {
                langs[i].AddCommand(c);
            }
        }
        return langs;
    } 
}



[System.Serializable]
public class AlgorythmHolder
{
    public CodeSerializable[] algorythms;

    public Algorythm[] GetAlgorytms()
    {
        Algorythm[] algs = new Algorythm[algorythms.Length];
        for (int i = 0; i < algorythms.Length; i++)
        {
            algs[i] = new Algorythm(algorythms[i].name);
            foreach (char c in algorythms[i].commands)
            {
                algs[i].AddCommand(c);
            }
        }
        return algs;
    }
}


[System.Serializable]
public class StructureHolder
{
    public CodeSerializable[] structures;

    public Structure[] GetStructures()
    {
        Structure[] sts = new Structure[structures.Length];
        for (int i = 0; i < structures.Length; i++)
        {
            sts[i] = new Structure(structures[i].name);
            foreach (char c in structures[i].commands)
            {
                sts[i].AddCommand(c);
            }
        }
        return sts;
    }
}
