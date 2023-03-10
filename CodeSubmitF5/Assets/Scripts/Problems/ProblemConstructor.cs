using Mono.Cecil;
using System;
using System.Collections.Generic;

//String[] names = {"Las tres hermanas", "Tuberías por doquier"};


public class ProblemConstructor
{ //Genera un problema aleatorio
    private List<Language> languages = new List<Language>();
    private List<Algorythm> algorythms = new List<Algorythm>();
    private List<Structure> structures = new List<Structure>();
    private float tMaximo = 100; //Por ejemplo por ahora
    private Random rnd;

    public ProblemConstructor()
    {
        rnd = new Random();
    }
    public ProblemConstructor(int seed)
    {
        rnd = new Random(seed);
    }

    public void AddLanguage(Language l)
    {
        this.languages.Add(l);
    }
    public void AddAlgorythm(Algorythm l)
    {
        this.algorythms.Add(l);
    }
    public void AddStructure(Structure l)
    {
        this.structures.Add(l);
    }
    public List<Language> GetLanguages()
    {
        return this.languages;
    }
    public List<Algorythm> GetAlgorythms()
    {
        return this.algorythms;
    }
    public List<Structure> GetStructure()
    {
        return this.structures;
    }


    public Problem generateProblem(float tIni)
    {
        Language l = this.languages[this.rnd.Next(this.languages.Count)];
        Algorythm a = this.algorythms[this.rnd.Next(this.algorythms.Count)];
        Structure e = this.structures[this.rnd.Next(this.structures.Count)];
        return new Problem(l, a, e, tIni, tMaximo);
    }
}