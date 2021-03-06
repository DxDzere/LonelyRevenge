﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    [SerializeField]

    public baseStats playerBaseStats;
	
    public struct baseStats
    {
        public float health;
        public float healthCap;
        public float physicalDamage;
        public float abilityDamage;
        public float defense;
        public float mana;
        public float manaCap;
        public float movementSpeed;
        public float attackSpeed;
        public float staminaCap;
        public float stamina;
    }
    public string name;
    enum state {Idle, Walk, Run, Attack, Dead, Hit, Jump}
    //anims
    //weapons
    public string description;
    Vector3 pos;
}
