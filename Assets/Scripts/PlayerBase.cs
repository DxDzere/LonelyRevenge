using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBasic
{
    [SerializeField]

    public playerStats stats;
    public float money;
    
    public struct playerStats
    {
        public float healthCap;
        public float strength;
        public float resist;
        public float manaCap;
        public float dexterity;
    }
    //controller
    public float xp, xpCap, lvl, lvlCap;
    //inventory


}
