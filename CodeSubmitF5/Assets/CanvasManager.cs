using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject elhdp;
    [SerializeField]
    GameObject belovedVideo;
    [SerializeField]
    GameObject videoFinMenu;
    [SerializeField]
    TMPro.TextMeshProUGUI feedbackText;
    private VideoPlayer vPlayer;
    private bool videoEnded = false;
    private bool videoWasPlaying = false;

    void Start()
    {
        vPlayer = belovedVideo.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (belovedVideo.activeInHierarchy)
        {
            if (videoWasPlaying && !vPlayer.isPlaying)
            {
                videoEnded = true;
                QuitVideo();
            }
            videoWasPlaying = vPlayer.isPlaying;
        }
        else
        {
            videoEnded = false;
            videoWasPlaying = false;
        }
    }

    public void PlayVideo()
    {
        if (elhdp.activeInHierarchy)
        {
            elhdp.SetActive(false);
            belovedVideo.SetActive(true);
        }
    }

    public void QuitVideo()
    {
        if (belovedVideo.activeInHierarchy)
        {
            videoFinMenu.SetActive(true);
            belovedVideo.SetActive(false);
        }
    }

    public void SetFeedbackText(string text)
    {
        feedbackText.text = text;
    }

    public void BackToMainGacha()
    {
        videoFinMenu.SetActive(false);
        elhdp.SetActive(true);
    }

    public bool VideoEnded()
    {
        return videoEnded;
    }
}
