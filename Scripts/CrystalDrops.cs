using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDrops : Interactable
{
    public string crystalTag;

    public override void Interacted(Player player)
    {
        player.CrystalChecker(crystalTag);
        Destroy(gameObject); // Destroy the crystal after collection
    }
}
