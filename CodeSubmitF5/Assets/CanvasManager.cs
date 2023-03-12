using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject elhdp;
    GameObject belovedVideo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elhdp.activeInHierarchy)
        {
            elhdp.SetActive(false);
            belovedVideo.SetActive(true);
        }
    }
}
