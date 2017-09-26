using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumibles : Items
{
    [SerializeField]

    public baseStats statsBase;
    public float time;

    public struct baseStats
    {
        public float healthCap;
        public float manaCap;
        public float health;
        public float defense;
        public float mana;
        public float stamina;
        public float attackSpeed;
        public float movementSpeed;
        public float attack;
    }

}
