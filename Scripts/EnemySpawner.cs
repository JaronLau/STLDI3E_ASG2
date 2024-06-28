/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: spawns enemies on interacting with the altar 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Interactable
{
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public GameObject enemy;
    public GameObject general;

    public Transform enemyPos1;
    public Transform enemyPos2;
    public Transform enemyPos3;
    public Transform enemyPos4;
    public Transform generalPos1;

    public override void Interacted(Player player)
    {
        EnemySpawn();
        Destroy(gameObject);
    }

    void EnemySpawn()
    {
        Instantiate(enemy, enemyPos1.position, enemyPos1.rotation);
        Instantiate(enemy, enemyPos2.position, enemyPos2.rotation);
        Instantiate(enemy, enemyPos3.position, enemyPos3.rotation);
        Instantiate(enemy, enemyPos4.position, enemyPos4.rotation);
        Instantiate(general, generalPos1.position, generalPos1.rotation);
        Debug.Log("Spawned enemy");
    }

}
