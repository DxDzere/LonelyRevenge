using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantaneos : Consumibles{

	public enum itemsInstantaneos {antidoto, pergaminoTeleport, elixirVida, elixirMana, Default}
    public changeState states;

    public struct changeState
    {
        float mana;
        float vida;
        Vector3 position;
        bool state;
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

    public override void Buy(PlayerBase _player)
    {
        if (_player.money >= priceBuy)
            _player.money -= priceBuy;
    }
}
