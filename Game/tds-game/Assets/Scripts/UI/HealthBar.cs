using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public void SetMaxHealth(int hp)
    {
        _slider.maxValue = hp;
        _slider.value = hp;
    }

    public void SetHealth(int hp)
    {
        _slider.value = hp;
    }
}
