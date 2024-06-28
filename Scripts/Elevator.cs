/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: elevator script called by elevator panel to open elevator and run animation of elevator 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public float openDuration;
    float currentDuration;
    public bool opening = false;
    public bool isOpen = false;
    private Vector3 startingPosition;
    private Vector3 targetPosition;

    public bool activateElevator = false;

    void OnTriggerStay(Collider collider)
    {
        activateElevator=true;
        Debug.Log("is activated");
    }
    void OnTriggerExit(Collider collider)
    {
        activateElevator = false;
        Debug.Log("Not activated");
    }

    public void OpenDoor()
    {
        if (!opening)
        {
            audioManager.PlaySFX(audioManager.elevator);
            startingPosition = transform.position;
            targetPosition = startingPosition;
            targetPosition.y -= 4.1f;
            opening = true;
            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (!opening)
        {
            audioManager.PlaySFX(audioManager.elevator);
            startingPosition = transform.position;
            targetPosition = startingPosition;
            targetPosition.y += 4.1f;
            opening = true;
            isOpen = false;
        }
    }

    void Update()
    {
        if (opening)
        {
            currentDuration += Time.deltaTime;
            float t = currentDuration / openDuration;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            if(currentDuration >= openDuration)
            {
                currentDuration = 1f;
                audioManager.PlaySFX(audioManager.elevator);
                transform.position = targetPosition;
                opening = false;
            }
        }
    }

    

}
