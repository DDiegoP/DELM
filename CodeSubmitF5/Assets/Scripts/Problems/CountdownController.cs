using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private Image fill;

    [SerializeField] private Slider slider;



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
