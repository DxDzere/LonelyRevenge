using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemasElementales : Gemas
{
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
