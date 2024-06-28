using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillStamina : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI staminaValue;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = player.currentStamina;
    }

    void Update()
    {
        float fillValue = player.currentStamina;
        slider.value = fillValue;
        staminaValue.text = player.currentStamina.ToString();
    }
}
