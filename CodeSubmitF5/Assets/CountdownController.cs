using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private Image fill;

    [SerializeField] private Slider slider;


    private void Start() {
        slider.value = 0;
        slider.maxValue = 100;
        fill.color = Color.blue;
    }

    public void setColor(Color toWhat)
    {
        fill.color = toWhat;
    }

    public void setValue(float toWhat)
    {
        slider.value = toWhat;
    }

    public void setMaxValue(float toWhat)
    {
        slider.maxValue = toWhat;
    }

}
