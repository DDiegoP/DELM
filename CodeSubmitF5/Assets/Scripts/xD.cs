using Mono.Cecil;
using System;
using System.Collections.Generic;

struct Instruction
{
    char key;
    string action;
}
class Code
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

class Algorythm : Code {
    public string algorythm;
    public Algorythm(string a) : base(){
        algorythm = a;
    }

    public override void use(Problem p)  {
        p.applyAlg(algorythm);
    }
}
class Language : Code {
    public string language;
    public Language(string l) 
    {
        language = l;
    }

    public override void use(Problem p)  {
        p.applyLang(language);
    }
}
class Structure : Code {
    public string structure;
    public Structure(string s)
    {
        structure = s;
    }

    public override void use(Problem p)  {
        p.applyStruct(structure);
    }
}



class Tab
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

class AlgTab : Tab {
    AlgTab() : base('a') {
        Algorythm a = new Algorythm("Backtracking");
        //a.addInstruction();
        codes.Add(a);
        codes.Add(new Algorythm("Divide y vencerás"));
        codes.Add(new Algorythm("Sort"));
    }
}

class LangTab : Tab
{
    LangTab() : base('l')
    {
        codes.Add(new Language("C++"));
        codes.Add(new Language("JS"));
        codes.Add(new Language("C#"));
    }
}

class StructTab : Tab
{
    StructTab() : base('s')
    {
        codes.Add(new Structure("Set"));
        codes.Add(new Structure("Unordered_Map"));
        codes.Add(new Structure("List"));
    }
}

class Problem
{
    private string language;
    private string algorythm;
    private string structure;

    private string submittedLanguage;
    private string submittedAlgorythm;
    private string submittedStructure;

    private bool correct;

    // Constructora que recibe el lenguaje, algorimo y estructura de datos necesarios para resolverlo
    public Problem(string l, string a, string s)
    {
        this.language = l;
        this.algorythm = a;
        this.structure = s;
        this.submittedLanguage = "";
        this.submittedAlgorythm = "";
        this.submittedStructure = "";
        this.correct = true;
    }
    // Comprueba si los datos introducidos son correctos
    private void checkCorrect()
    {
        correct = language == submittedLanguage &&
                  algorythm == submittedAlgorythm &&
                  structure == submittedStructure;
    }
    // Marca el lenguaje pasada como la usada
    public void applyLang(string l)
    {
        submittedLanguage = l;
    }
    // Marca el algoritmo pasada como la usada
    public void applyAlg(string a)
    {
        submittedAlgorythm = a;
    }
    // Marca la estructura pasada como la usada
    public void applyStruct(string s)
    {
        submittedStructure = s;
    }
}