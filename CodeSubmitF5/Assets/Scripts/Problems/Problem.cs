using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//String[] names = {"Las tres hermanas", "Tuber�as por doquier"};

public class Problem : MonoBehaviour
{
    private ProblemSlot slot;
    
    private Language askedLanguage;
    private char[] askedLangCommands;
    private Algorythm askedAlgorythm;
    private char[] askedAlgCommands;
    private Structure askedStructure;
    private char[] askedStructCommands;
    private Proffessor proffessor;
    private float tMaximo;

    private Language submittedLanguage;
    private char[] submittedLangCommands;
    private Algorythm submittedAlgorythm;
    private char[] submittedAlgCommands;
    private Structure submittedStructure;
    private char[] submittedStructCommands;

    private bool correct;

    private float timeLimit = 0;

    // Constructora que recibe el lenguaje, algorimo y estructura de datos necesarios para resolverlo
    public void Set(Proffessor p, Language l, Algorythm a, Structure s, float tMaximo)
    {
        this.proffessor= p;
        List<string> tasks = this.proffessor.GetAvailableTasks();
        this.name = tasks[Random.Range(0, tasks.Count)];
        this.askedLanguage = l;
        this.askedAlgorythm = a;
        this.askedStructure = s;
        this.askedLangCommands = l.GetCommands();
        this.askedStructCommands = s.GetCommands();
        this.askedAlgCommands = a.GetCommands();
        this.submittedLanguage = null;
        this.submittedAlgorythm = null;
        this.submittedStructure = null;
        this.correct = true;
        this.tMaximo = tMaximo;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLimit < tMaximo)
        {
            timeLimit += Time.deltaTime;
        }
    }

    // Comprueba si los datos introducidos son correctos
    private void CheckCorrect()
    {
        CheckCorrect(askedAlgCommands, submittedAlgCommands);
        CheckCorrect(askedLangCommands, submittedLangCommands);
        CheckCorrect(askedStructCommands, submittedStructCommands);
        if (correct)
        {
            correct = askedLanguage == submittedLanguage &&
                      askedAlgorythm == submittedAlgorythm &&
                      askedStructure == submittedStructure;
        }
    }
    // Comprueba si los arrays de comandos introducidos son coincidentes y asigna correct
    private void CheckCorrect(char[] asked, char[] submitted) {
        for (int i = 0; i < asked.Length && correct; ++i)
        {
            if (asked[i] == submitted[i]) correct = false;
        }
    }

    // Marca el lenguaje pasada como la usada
    public void SubmitLanguage(Language l)
    {
        submittedLanguage = l;
    }
    // Marca el algoritmo pasada como la usada
    public void SubmitAlgorythm(Algorythm a)
    {
        submittedAlgorythm = a;
    }
    // Marca la estructura pasada como la usada
    public void SubmitStructure(Structure s)
    {
        submittedStructure = s;
    }
    public void SubmitCommand(char c)
    {

    }
    //public float TiempoRestante(float tActual){
    //    return (tIni + tMaximo) - tActual;
    //}
    public ProblemSlot GetSlot()
    {
        return slot;
    }

    public void SetSlot(ProblemSlot slot)
    {
        this.slot = slot;
    }

    public bool IsTimedOut()
    {
        return timeLimit >= tMaximo;
    }

    public Proffessor GetProffessor()
    {
        return proffessor;
    }
}