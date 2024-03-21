using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthScript : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Slider hpSlider;
    public TextMeshProUGUI healthText;
    private Unit unit;
    public void SetUp(Unit unit){
        this.unit=unit;
        healthText.text=""+unit.maxHealth+ "/"+unit.maxHealth;
        nameText.text=unit.name;
        hpSlider.maxValue = unit.maxHealth;
        hpSlider.value = unit.currHealth;

    }
    public void SetHealth(int health){
        healthText.text=""+health+ "/"+unit.maxHealth;
        hpSlider.value = health;
    }
}
