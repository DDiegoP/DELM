using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource musicOrigin;
    // Start is called before the first frame update
    void Start()
    {
        musicOrigin=GetComponent<AudioSource>();
        DontDestroyOnLoad(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Debug.Log("AAAAAAA");
        musicOrigin.Stop();
    }
}
