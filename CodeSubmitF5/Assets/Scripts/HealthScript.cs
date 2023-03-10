using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    public Slider healthBar;

    static public int MAX_HEALTH = 100;
    public int curHealth = MAX_HEALTH;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue =  MAX_HEALTH;
        healthBar.value = curHealth;
    }

    public void TakeDamage(int damage){
        if(curHealth - damage <= 0){
            curHealth = 0;
            //Hacer que pierda el juego
        }else if(curHealth - damage >= MAX_HEALTH){
            curHealth = MAX_HEALTH;
        }else{
            curHealth -= damage;
        }
        healthBar.value = curHealth;
    }
}
