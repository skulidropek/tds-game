using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpirienceBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxXP(int hp)
    {
        _slider.maxValue = hp;
    }

    public void SetXP(int hp)
    {
        _slider.value = hp;
    }
}
