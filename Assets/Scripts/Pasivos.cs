using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasivos : Consumibles {

	public enum pocionesPasivas {pocionFuerza, pocionAgilidad, pocionDefensa, pocionVitalidad, pocionEnergia, pocionInmunidad, Default};
    public float potionTime;
    

    public override void Use(PlayerBase _player)
    {
        _player.playerBaseStats.healthCap += statsBase.health;
        _player.playerBaseStats.health += statsBase.health;
        _player.playerBaseStats.manaCap += statsBase.mana;
        _player.playerBaseStats.mana += statsBase.mana;
        _player.playerBaseStats.staminaCap += statsBase.stamina;
        _player.playerBaseStats.stamina += statsBase.stamina;
        _player.playerBaseStats.defense += statsBase.defense;
        _player.playerBaseStats.physicalDamage += statsBase.attack;
        _player.playerBaseStats.abilityDamage += statsBase.attack;
        _player.playerBaseStats.movementSpeed += statsBase.movementSpeed;
        _player.playerBaseStats.attackSpeed += statsBase.attackSpeed;
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
        if(_player.money>=priceBuy)
            _player.money -= priceBuy;
    }
}
