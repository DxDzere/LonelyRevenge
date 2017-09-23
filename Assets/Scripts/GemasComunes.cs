using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemasComunes : Gemas {

    struct statsGemas
    {
        int healthCap;
        int attack;
        int defense;
        int manaCap;
        int dexterity;
    }

    public override void Use(PlayerBase _player)
    {

    }

    public override void Throw()
    {
        base.Throw();
    }

    public override void Sell(PlayerBase _player)
    {
        _player.money += priceSell;
    }
}
