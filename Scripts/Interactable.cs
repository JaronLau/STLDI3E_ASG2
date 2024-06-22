using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interacted(Player player)
    {
        Debug.Log($"{gameObject.name} interacted by {player.gameObject.name}");
    }
    
    // Start is called before the first frame update
}
