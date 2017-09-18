using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : Equipables {
    
    public string clase;
    public statsArma statsBasicA;

    public struct statsArma
    {
        public float defense;
        public float attackMin;
        public float attackMax;
        public float dexterity;
    }

    public override void Equip(PlayerBase _player)
    {

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
}
