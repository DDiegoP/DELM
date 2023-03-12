using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Problem : MonoBehaviour
{
    private ProblemSlot slot;
    
    private Language askedLanguage;
    public Language AskedLanguage
    {
        get { return askedLanguage; }
    }
    private Command[] askedLangCommands;
    
    private Algorythm askedAlgorythm;
    public Algorythm AskedAlgorythm { 
        get => askedAlgorythm;
    }
    private Command[] askedAlgCommands;
    
    private Structure askedStructure;
    public Structure AskedStructure
    {
        get { return askedStructure; }
    }
    private Command[] askedStructCommands;
    
    private Proffessor proffessor;
    private float tMaximo;

    private Language submittedLanguage;
    private Command[] submittedLangCommands;
    private Algorythm submittedAlgorythm;
    private Command[] submittedAlgCommands;
    private Structure submittedStructure;
    private Command[] submittedStructCommands;

    private CountdownController cdCntrl;
    private bool correct;

    private float timeLimit = 0;

    // Constructora que recibe el lenguaje, algorimo y estructura de datos necesarios para resolverlo
    public void Set(Proffessor p, Language l, Algorythm a, Structure s, float tMaximo)
    {
        this.proffessor = p;
        List<string> tasks = this.proffessor.GetAvailableTasks();
        this.name = tasks[Random.Range(0, tasks.Count)];
        this.askedLanguage = l;
        this.askedAlgorythm = a;
        this.askedStructure = s;
        this.askedLangCommands = l.GetCommands();
        this.askedAlgCommands = a.GetCommands();
        this.askedStructCommands = s.GetCommands();
        this.submittedLanguage = null;
        this.submittedAlgorythm = null;
        this.submittedStructure = null;
        this.correct = true;
        this.tMaximo = tMaximo;
        this.timeLimit = 0;
        this.slot.SetTask(this);
        this.cdCntrl = slot.gameObject.GetComponent<CountdownController>();
        this.cdCntrl.setMaxValue(this.tMaximo);
        //this.cdCntrl.setValue(this.tMaximo);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLimit < tMaximo)
            timeLimit += Time.deltaTime;

        float t = timeLimit / tMaximo;
        float r = Mathf.Lerp(0, 1, t);
        float g = Mathf.Lerp(1, 0, t);
        cdCntrl.setColor(new Color(r, g, 0, 1));
        cdCntrl.setValue(tMaximo - timeLimit);
        
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
                      AskedAlgorythm == submittedAlgorythm &&
                      askedStructure == submittedStructure;
        }
    }
    // Comprueba si los arrays de comandos introducidos son coincidentes y asigna correct
    private void CheckCorrect(Command[] asked, Command[] submitted) {
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

    public int GetPoints(){
        float aux = this.askedAlgorythm.puntos + this.askedLanguage.puntos + this.AskedStructure.puntos;
        return (int)(aux*this.proffessor.puntos);
    }
}