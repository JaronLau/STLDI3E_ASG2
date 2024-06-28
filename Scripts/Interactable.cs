/*
 * Author: Lau Keng Yong, Jaron 
 * Date: 6/25/2024
 * Description: parent script interactable, all interactable functions overrides this function
 */
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
