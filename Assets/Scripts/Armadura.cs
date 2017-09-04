using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : Equipables {

    enum partesArmadura { casco, pechera, grebas, guantes, pantalones};
    public statsArmadura statsBasicArm;

    public struct statsArmadura
    {
        public float dexterity;
        public float defense;
    }

    public override void Repair()
    {
        base.Repair();
    }
}
