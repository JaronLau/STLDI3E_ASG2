/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: elevator panel that player interacts with and calls function in elevator script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : Interactable
{
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public Elevator elevator;

    public override void Interacted(Player player)
    {
        if (elevator != null && elevator.activateElevator == true)
        {
            if (!elevator.isOpen)
            {
                audioManager.PlaySFX(audioManager.panels);
                elevator.OpenDoor();
                
            }
            else
            {
                audioManager.PlaySFX(audioManager.panels);
                elevator.CloseDoor();
                
            }
        }
        else
        {
            audioManager.PlaySFX(audioManager.errorInteract);
        }
    }
}

