/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: script that runs siding door and its animations, opening door 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
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
    [SerializeField] float moveDistance = -2f;

    public void OpenDoor()
    {
        if (!opening)
        {
            startingPosition = transform.position;
            targetPosition = startingPosition;
            targetPosition.z += moveDistance;
            opening = true;
            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (!opening)
        {
            startingPosition = transform.position;
            targetPosition = startingPosition;
            targetPosition.z -= moveDistance;
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
            if (currentDuration >= openDuration)
            {
                currentDuration = 1f;
                transform.position = targetPosition;
                opening = false;
            }
        }
    }

    public void DoorToggle()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    
}
