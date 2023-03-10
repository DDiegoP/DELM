using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    private ProblemConstructor pconstructor;
    private float ultimaTarea;
    private const float TIEMPO_ENTRE_TAREAS = 1000000;
    private List<Problem> problems = new List<Problem>();
    private int MAX_PROBLEMAS = 3; 
    [SerializeField]
    private Problem ProblemPrefab;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.pconstructor = new ProblemConstructor(); //Aqui podemos ponerle seed si queremos
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - ultimaTarea >= TIEMPO_ENTRE_TAREAS && problems.Count < MAX_PROBLEMAS){
            problems.Add(this.pconstructor.generateProblem(Time.time));
        }
    }
    
}
