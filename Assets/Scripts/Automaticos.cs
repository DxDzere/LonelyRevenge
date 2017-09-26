using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automaticos : Consumibles{

    public enum pociones {pocionVida, pocionMana}

    public override void Use(PlayerBase _player)
    {
        float potionTime = 3f;
        float rechargeHealth = 0f;
        float rechargeMana = 0f;

        for (float i=0f; i<potionTime; i+=Time.deltaTime)
        {
            if (rechargeHealth < statsBase.healthCap && _player.playerBaseStats.health < _player.playerBaseStats.healthCap)
            {
                _player.playerBaseStats.health += statsBase.health;
                rechargeHealth += statsBase.health;
            }
            if (rechargeMana < statsBase.manaCap && _player.playerBaseStats.mana < _player.playerBaseStats.manaCap)
            {
                _player.playerBaseStats.mana += statsBase.mana;
                rechargeMana += statsBase.mana;
            }
        }
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
