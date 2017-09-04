using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    [SerializeField]

    public type kind;
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
    public string name;
    public enum type {Warrior, SpellCaster, Rogue, Priest, Archer}
    enum state {Idle, Walk, Run, Attack, Dead, Hit, Jump}
    //anims
    //weapons
    public string description;
    Vector3 pos;
}
