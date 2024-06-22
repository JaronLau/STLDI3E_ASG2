using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillHealth : MonoBehaviour
{
    public Health playerHealth;
    public Image fillImage;
    private Slider slider;
    public TextMeshProUGUI healthValue;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.playerHealth;
        slider.value = fillValue;
        healthValue.text = playerHealth.currentHealth.ToString();
    }
}
