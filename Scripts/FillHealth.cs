/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: canvas health bar, controlling fill value of health bar
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillHealth : MonoBehaviour
{
    public Player Health;
    private Slider slider;
    public TextMeshProUGUI healthValue;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = Health.currentHealth;
        slider.maxValue = Health.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Health.currentHealth; // Update the slider's value to match the player's current health
        healthValue.text = Mathf.RoundToInt(Health.currentHealth).ToString();
    }
}
