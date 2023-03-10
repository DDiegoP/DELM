using System.Collections

public enum language
{
    CS,
    CPP,
    Java,
    Python
}

public enum algorythm{
    Voraz,
    Vuelta_atras
}

public enum eda{
    Arbol,
    Heap,
    Queue,
    Map
}

class Event
{
    private char key;
    

    public Event(char k) 
    { 
        this.key = k;
    }
    public void use(Problem p)
    {
        
    }
}



class Tab
{
    private char key;
    private Event[] events;
    public Tab(char k)
    {
        this.key = k;
    }
    public void open()
    {
        
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
    public Problem(language l, algorythm a, eda s)
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


class ProblemConstructor { //Genera un problema aleatorio
    
    private List<language> languages = new List<language>();
    private List<algorythm> algorythms = new List<algorythm>();
    private List<eda> edas = new List<eda>();

    public ProblemConstructor(){
        rnd = new Random()
    }
    public ProblemConstructor(int seed){
        rnd = new Random(seed);
    }

    public void AddLanguage(language l){
        this.languages.Add(l);
    }
    public void AddAlgorythm(algorythm l){
        this.algorythms.Add(l);
    }
    public void AddEda(eda l){
        this.edas.Add(l);
    }
    public List<language> GetLanguages(){
        return this.languages;
    }
    public List<algorythm> GetAlgorythms(){
        return this.algorythms;
    }
    public List<eda> GetEda(){
        return this.edas;
    }
    

    public Problem generateProblem(){
        language l = this.languages[this.rnd(0,this.languages.count)];
        algorythm a = this.algorythm[this.rnd(0,this.algorythms.count)];
        eda e = this.edas[this.rnd(0, this.edas.count)];
        return new Problem(l, a, e);
    }
}