using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Armadura : Equipables
{
    enum partesArmadura { casco, pechera, perneras, guantes, pantalones, Default};
    public statsArmadura statsBasicArm;

    public struct statsArmadura
    {
        public float movementSpeed;
        public float defense;
        public float durability;
        public float durabilityCap;
    }
    public override void Use(PlayerBase _player)
    {
        _player.playerBaseStats.defense += statsBasicArm.defense;
        _player.playerBaseStats.movementSpeed += statsBasicArm.movementSpeed;
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
			statsBasicArm.defense += (statsBasicArm.defense * multiplicator);
			statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap * multiplicator);
			statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed * multiplicator);
			statsBasicArm.durability = statsBasicArm.durabilityCap;
		}
		if(_player.money >= priceUpgrade)
        	_player.money -= priceUpgrade;
    }

    public override void Repair(PlayerBase _player)
    {
        if (_player.money >= priceRepair)
        {
            statsBasicArm.durability = statsBasicArm.durabilityCap;
            _player.money -= priceRepair;
        }
    }
}






































































/*
            
    */