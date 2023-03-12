using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerCoding : MonoBehaviour
{
    [SerializeField]
    GameObject visualUI;

    AudioSource audioSource;
    AudioSource otherAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        otherAudioSource= visualUI.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (visualUI.activeInHierarchy)
        {
            audioSource.Stop();
            //otherAudioSource.PlayDelayed(1);
            
        }
        else if(!visualUI.activeInHierarchy&& !audioSource.isPlaying)
        {
            otherAudioSource.Stop();
            audioSource.Play();
        }
    }
}
