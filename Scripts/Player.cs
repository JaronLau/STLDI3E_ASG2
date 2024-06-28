/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: player script that runs interactivity, stores health and other player variables 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    public MenuUI menuUI;
    [SerializeField] public float currentHealth = 100f;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float regenAmount = 1f;
    [SerializeField] public float regenInterval = 2f;

    [Header("Player Camera")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactionDistance = 5f;

    private Interactable currentInteractable;

    [Header("Player Dash")]
    [SerializeField] public float currentStamina;
    [SerializeField] public float maxStamina = 80f;
    [SerializeField] public float staminaRegen = 0.1f;
    [SerializeField] public int dashStamina = 5;
    [SerializeField] public float dashTime = 0.2f;
    [SerializeField] public float dashSpeed = 2f;

    [Header("Player Weapons")]
    [SerializeField] public Gun gun;

    public bool crystalCollect = false;
    public int keyCount = 0;

    void Start()
    {
        currentStamina = maxStamina;
        StartCoroutine(RegenerateHealth());
    }
    private void Update()
    {
        if (currentStamina < maxStamina) 
        {
            StaminaConsumption(-staminaRegen);
        }

        //raycasting for player camera
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                Debug.Log("Interactable in sight: " + hitInfo.transform.name);
            }
            else
            {
                currentInteractable = null;
            }
        }
        else
        {
            currentInteractable = null;
        }


    }

    public void OnUI()
    {
        menuUI.UI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player death
        Debug.Log("Player has died.");
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenInterval);

            if (currentHealth < maxHealth)
            {
                currentHealth = Mathf.Min(currentHealth + regenAmount, maxHealth);
                Debug.Log("Health regenerated. Current health: " + currentHealth);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            int damage = collision.gameObject.GetComponent<EnemyHealth>().damage;
            TakeDamage(damage);
        }
    }
    

    /// <summary>
    /// function that reads on keypress f, using unity input manager
    /// </summary>
    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interacted(this);
        }
    }

    public void OnFire()
    {
        if (gun != null)
        {
            gun.Fire();
        }
    }

    public void CrystalChecker(string crystalTag)
    {
        if (crystalTag == "Crystal2")
        {
            crystalCollect = true;
        }
    }

    public void KeyCollect(int key)
    {
        keyCount += key;
    }
    

    //stamina and dashing functions

    /// <summary>
    /// function that manages stamina consuption
    /// </summary>
    /// <param name="energy"></param>
    void StaminaConsumption(float energy)
    {
        currentStamina -= energy;
    }
    /// <summary>
    /// keypress input for dash
    /// </summary>
    void OnDash()
    {
        if(currentStamina > dashStamina)
        {
            StartCoroutine(Dash());
            Debug.Log("Dash active");
        }
        
    }
    /// <summary>
    /// dashes backwards
    /// </summary>
    /// <returns></returns>
    IEnumerator Dash()
    {
        float startTime = Time.time;
        while ((Time.time < startTime + dashTime)&& (currentStamina > dashStamina))
        {
            transform.Translate(Vector3.back * dashSpeed);
            StaminaConsumption(dashStamina);
            yield return null;
        }
    }



}