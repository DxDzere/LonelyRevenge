using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    [SerializeField]
    struct baseStats
    {
        int health;
        int healthCap;
        float physicalDamage;
        float abilityDamage;
        int strength;
        int defense;
        int mana;
        int manaCap;
        float movementSpeed;
        float attackSpeed;
        int dexterity;
    }
    string name;
    enum type {Warrior, SpellCaster, Rogue, Priest, Archer}
    enum state {Idle, Walk, Run, Attack, Dead, Hit, Jump}
    //anims
    //weapons
    string description;
    Vector3 pos;
}
