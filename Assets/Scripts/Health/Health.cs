using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject entity;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int hp;

    //Health = value of the slider
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    //Set the health
    public void SetHealh(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Death()
    {
        Destroy(entity);
    }

    void Update()
    {
        if (slider.value <= 0)
            Death();
    }
}
