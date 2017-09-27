using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joyeria : Equipables {

    enum tipoJoyeria {anillos, colgantes}
	public statsJoyeria stats;

	public struct statsJoyeria
    {
        public float movementSpeed;
        public float attackSpeed;
        public float manaCap;
        public float healthCap;
        public float staminaCap;
    }
	
	public override void Use(PlayerBase _player)
    {
        if (lvl == 1)
        {
            _player.playerBaseStats.movementSpeed += stats.movementSpeed;
            _player.playerBaseStats.manaCap += stats.manaCap;
            _player.playerBaseStats.healthCap += stats.healthCap;
            _player.playerBaseStats.attackSpeed += stats.attackSpeed;
            _player.playerBaseStats.staminaCap += stats.staminaCap;
        }
        else
        {
            _player.playerBaseStats.movementSpeed += stats.movementSpeed * lvl * 0.3f;
            _player.playerBaseStats.manaCap += stats.manaCap * lvl;
            _player.playerBaseStats.healthCap += stats.healthCap * lvl;
            _player.playerBaseStats.attackSpeed += stats.attackSpeed * lvl;
            _player.playerBaseStats.staminaCap += stats.staminaCap * lvl;
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

    public override void Upgrade(PlayerBase _player)
    {
        float upgrade = Random.Range(1, 100);
        float multiplicator = 0.05f;
		if (_player.money >= priceUpgrade && upgrade <= upgradeSuccessRate) {
			grade++;
			switch ((int)grade) {
			case 4:
				upgradeSuccessRate = 85;
				multiplicator = multiplicator * 1.1f;
				break;
			case 8:
				upgradeSuccessRate = 65;
				multiplicator = multiplicator * 1.2f;
				break;
			case 12:
				upgradeSuccessRate = 40;
				multiplicator = multiplicator * 1.3f;
				break;
			case 16:
				upgradeSuccessRate = 10;
				multiplicator = multiplicator * 1.4f;
				break;
			case 19:
				upgradeSuccessRate = 5;
				multiplicator = multiplicator * 1.5f;
				break;
			case 20:
				upgradeSuccessRate = 0;
				multiplicator = multiplicator * 2f;
				break;
			}
			stats.movementSpeed += (stats.movementSpeed * multiplicator);
            stats.manaCap += stats.manaCap * multiplicator;
            stats.healthCap += stats.healthCap * multiplicator;
            stats.attackSpeed += stats.attackSpeed * multiplicator;
            stats.staminaCap += stats.staminaCap * multiplicator;
		}
		if(_player.money >= priceUpgrade)
        {
        	_player.money -= priceUpgrade;
		}
    }
}

