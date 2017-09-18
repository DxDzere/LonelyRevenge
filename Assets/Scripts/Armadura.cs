using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : Equipables
{
    enum partesArmadura { casco, pechera, grebas, guantes, pantalones};
    public statsArmadura statsBasicArm;

    public struct statsArmadura
    {
        public float dexterity;
        public float defense;
        public float durability;
        public float durabilityCap;
    }
    public override void Equip(PlayerBase _player)
    {
        _player.stats.defense += statsBasicArm.defense;
        _player.stats.dexterity += statsBasicArm.dexterity;
    }

    public override void Throw()
    {
        base.Throw();
    }

    public override void Sell()
    {
        base.Sell();
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }

    public override void Repair()
    {
        statsBasicArm.durability = statsBasicArm.durabilityCap;
    }
}
