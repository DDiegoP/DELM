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