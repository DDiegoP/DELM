using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + this.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int score){
        this.score += score;
        scoreText.text = "Score: " + this.score;

    }
}
