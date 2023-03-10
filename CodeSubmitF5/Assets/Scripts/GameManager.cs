using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xD;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    private xd.ProblemConstructor pconstructor;

    void Awake(){
        if(instance == null){
            instance == this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.pconstructor = new xD.ProblemConstructor(); //Aqui podemos ponerle seed si queremos
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
