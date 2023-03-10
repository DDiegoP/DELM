using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//String[] names = {"Las tres hermanas", "Tuberías por doquier"};

public class Problem : MonoBehaviour
{

    [SerializeField] private Language askedLanguage;
    [SerializeField] private char[] askedLangCommands;
    [SerializeField] private Algorythm askedAlgorythm;
    [SerializeField] private char[] askedAlgCommands;
    [SerializeField] private Structure askedStructure;
    [SerializeField] private char[] askedStructCommands;

    private float tIni;
    private float tMaximo;

    private Language submittedLanguage;
    private char[] submittedLangCommands;
    private Algorythm submittedAlgorythm;
    private char[] submittedAlgCommands;
    private Structure submittedStructure;
    private char[] submittedStructCommands;

    private bool correct;

    // Constructora que recibe el lenguaje, algorimo y estructura de datos necesarios para resolverlo
    public Problem(Language l, Algorythm a, Structure s, float tIni,float tMaximo)
    {
        this.askedLanguage = l;
        this.askedAlgorythm = a;
        this.askedStructure = s;
        this.submittedLanguage = null;
        this.submittedAlgorythm = null;
        this.submittedStructure = null;
        this.correct = true;
        this.tIni = tIni;
        this.tMaximo = tMaximo;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > (this.tIni + this.tMaximo)){
            //transform.parent.gameObject.GetComponent<ProblemHolder>().timeOutProblem(this);
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
    public float TiempoRestante(float tActual){
        return (tIni + tMaximo) - tActual;
    }

}