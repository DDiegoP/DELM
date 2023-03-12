using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject elhdp;
    [SerializeField]
    GameObject belovedVideo;

    public void PlayVideo()
    {
        if (elhdp.activeInHierarchy)
        {
            elhdp.SetActive(false);
            belovedVideo.SetActive(true);
        }
    }
}
