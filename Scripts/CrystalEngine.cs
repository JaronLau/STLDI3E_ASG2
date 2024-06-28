using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalEngine : Interactable
{
    private AudioManager audioManager;

    public GameObject crystalObject;
    public Transform spawn;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void Interacted(Player player)
    {
        if (player.crystalCollect)
        {
            Instantiate(crystalObject, spawn.position, spawn.rotation);
        }
    }
}
