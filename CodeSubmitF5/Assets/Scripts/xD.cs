using System;

class Code
{
    private tuple<char, string> instruction;

    public Code(char k) 
    { 
 
    }
    public void use(Problem p)
    {
        
    }
}

class Algorythm : Code {
    public string algorythm;
    public Algorythm(string a, char k) {
        this.key = k;
        algorythm = a;
    }

    public override void use(Problem p)  {
        p.applyAlg(algorythm);
    }
}
class Language : Code {
    public string language;
    public Language(string l, char k) {
        this.key = k;
        language = l;
    }

    public override void use(Problem p)  {
        p.applyLang(language);
    }
}
class Structure : Code {
    public string structure;
    public Structure(string s, char k) {
        this.key = k;
        structure = s;
    }

    public override void use(Problem p)  {
        p.applyStruct(structure);
    }
}



class Tab
{
    private char key;
    private Code[] codes = new Code[7];
    public Tab(char k)
    {
        this.key = k;
    }
    public void open()
    {

    }
}

class AlgTab : Tab {
    AlgTab() {
        codes[i] = new Algorythm("Backtracking", 'b');
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