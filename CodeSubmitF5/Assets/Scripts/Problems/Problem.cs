using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem : MonoBehaviour
{

    [SerializeField]
    private Language language;
    private Algorythm algorythm;
    private Structure structure;
    private float tIni;
    private float tMaximo;

    private Language submittedLanguage;
    private Algorythm submittedAlgorythm;
    private Structure submittedStructure;

    private bool correct;

    // Constructora que recibe el lenguaje, algorimo y estructura de datos necesarios para resolverlo
    public Problem(Language l, Algorythm a, Structure s, float tIni,float tMaximo)
    {
        this.language = l;
        this.algorythm = a;
        this.structure = s;
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
    private void checkCorrect()
    {
        correct = language == submittedLanguage &&
                  algorythm == submittedAlgorythm &&
                  structure == submittedStructure;
    }
    // Marca el lenguaje pasada como la usada
    public void applyLang(Language l)
    {
        submittedLanguage = l;
    }
    // Marca el algoritmo pasada como la usada
    public void applyAlg(Algorythm a)
    {
        submittedAlgorythm = a;
    }
    // Marca la estructura pasada como la usada
    public void applyStruct(Structure s)
    {
        submittedStructure = s;
    }
    public float TiempoRestante(float tActual){
        return (tIni + tMaximo) - tActual;
    }

}
