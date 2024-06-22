using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : Interactable
{
    public SlidingDoor door;

    public override void Interacted(Player player)
    {
        if (door != null)
        {
            door.DoorToggle();
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
