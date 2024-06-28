/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: player interacts with this to call sliding door script to open door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : Interactable
{
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public SlidingDoor door;

    public override void Interacted(Player player)
    {
        if (door != null)
        {
            audioManager.PlaySFX(audioManager.panels);
            door.DoorToggle();
        }
        else
        {
            audioManager.PlaySFX(audioManager.errorInteract);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
