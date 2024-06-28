using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public float damage = 5f;
    public float range = 50f;
    public float fireRate = 5f;
    private float nextFire = 0f;

    public Transform Camera;
    public GameObject player;

    public ParticleSystem muzzle;
    public GameObject Impact;

    public void Fire()
    {
        
        Debug.DrawLine(Camera.position, Camera.position + (Camera.forward * range), Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, range))
        {
            Debug.Log("enemy in sight: " + hit.transform.name);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject impactFrame = Instantiate(Impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactFrame, .4f);
        }
        muzzle.Play();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFire)
        {
            Fire();
            nextFire = Time.time + 1f / fireRate; // Set the time for the next allowed fire
        }
    }
}
