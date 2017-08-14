using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBasic
{
    [SerializeField]
    struct modificableStats
    {
        int healthCap;
        int attack;
        int defense;
        int manaCap;
        int dexterity;
    }
    //controller
    int xp, xpCap, lvl, lvlCap;
    //inventory
    //stat modification
}
