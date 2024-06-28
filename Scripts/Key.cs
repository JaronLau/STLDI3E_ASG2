using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public int keyCount = 1;

    public override void Interacted(Player player)
    {
        player.KeyCollect(keyCount);
        Destroy(gameObject);
    }
}
