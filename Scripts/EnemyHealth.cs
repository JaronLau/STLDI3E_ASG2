using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health = 50f;
    [SerializeField] public int damage = 15;

    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public GameObject key;
    public GameObject crystal;
    public Transform dropPosition;

    public void TakeDamage (float amount)
    {
        health -= amount;
        audioManager.PlaySFX(audioManager.death);
        if (health <= 0)
        {
            Die();
        }

        void Die()
        {
            if (dropPosition == null)
            {
                Debug.LogError("Drop position is not assigned.");
                return;
            }

            if (CompareTag("General"))
            {
                // Drop key
                Instantiate(key, dropPosition.position, dropPosition.rotation);
            }
            else if (CompareTag("Boss"))
            {
                // Drop crystal
                Instantiate(crystal, dropPosition.position, dropPosition.rotation);
            }

            Destroy(gameObject);

        }
    }
}
