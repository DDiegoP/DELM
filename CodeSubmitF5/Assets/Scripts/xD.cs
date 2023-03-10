using Mono.Cecil;
using System;
using System.Collections.Generic;

//String[] names = {"Las tres hermanas", "Tuberías por doquier"};

public struct Instruction
{
    char key;
    string action;
}
public class Code
{
    private List<Instruction> instructions;

    public Code() 
    { 
 
    }
    public virtual void use(Problem p)
    {
        
    }
    public void addInstruction(Instruction inst)
    {
        instructions.Add(inst);
    }
}

public class Algorythm : Code {
    public string algorythm;
    public Algorythm(string a) : base(){
        algorythm = a;
    }

    public override void use(Problem p)  {
        p.applyAlg(this);
    }
}
public class Language : Code {
    public string language;
    public Language(string l) 
    {
        language = l;
    }

    public override void use(Problem p)  {
        p.applyLang(this);
    }
}
public class Structure : Code {
    public string structure;
    public Structure(string s)
    {
        structure = s;
    }

    public override void use(Problem p)  {
        p.applyStruct(this);
    }
}



public class Tab
{
    private char key;
    protected List<Code> codes;
    public Tab(char k)
    {
        this.key = k;
    }
    public void open()
    {

    }
}

public class AlgTab : Tab {
    AlgTab() : base('a') {
        Algorythm a = new Algorythm("Backtracking");
        //a.addInstruction();
        codes.Add(a);
        codes.Add(new Algorythm("Divide y vencer�s"));
        codes.Add(new Algorythm("Sort"));
    }
}

public class LangTab : Tab
{
    LangTab() : base('l')
    {
        codes.Add(new Language("C++"));
        codes.Add(new Language("JS"));
        codes.Add(new Language("C#"));
    }
}

public class StructTab : Tab
{
    StructTab() : base('s')
    {
        codes.Add(new Structure("Set"));
        codes.Add(new Structure("Unordered_Map"));
        codes.Add(new Structure("List"));
    }
}


public class ProblemConstructor { //Genera un problema aleatorio
    private List<Language> languages = new List<Language>();
    private List<Algorythm> algorythms = new List<Algorythm>();
    private List<Structure> structures = new List<Structure>();
    private float tMaximo = 100; //Por ejemplo por ahora
    private Random rnd;

    public ProblemConstructor(){
        rnd = new Random();
    }
    public ProblemConstructor(int seed){
        rnd = new Random(seed);
    }

    public void AddLanguage(Language l){
        this.languages.Add(l);
    }
    public void AddAlgorythm(Algorythm l){
        this.algorythms.Add(l);
    }
    public void AddStructure(Structure l){
        this.structures.Add(l);
    }
    public List<Language> GetLanguages(){
        return this.languages;
    }
    public List<Algorythm> GetAlgorythms(){
        return this.algorythms;
    }
    public List<Structure> GetStructure(){
        return this.structures;
    }
    

    public Problem generateProblem(float tIni){
        Language l = this.languages[this.rnd.Next(this.languages.Count)];
        Algorythm a = this.algorythms[this.rnd.Next(this.algorythms.Count)];
        Structure e = this.structures[this.rnd.Next(this.structures.Count)];
        return new Problem(l, a, e, tIni, tMaximo);
    }
}