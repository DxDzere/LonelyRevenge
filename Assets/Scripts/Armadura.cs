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
    public override void Equip(PlayerBase _player)
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
        if (_player.money >= priceRepair && upgrade <= upgradeSuccessRate)
        {
            grade++;
            switch ((int)grade)
            {
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
            if (grade <= 4)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.05f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.05f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.05f);
                if (grade == 4)
                {
                    upgradeSuccessRate = 85;
                }
            }
            else if (grade >= 5 && grade <= 8)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.07f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.07f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.07f);
                if (grade == 8)
                {
                    upgradeSuccessRate = 65;
                }
            }
            else if (grade >= 9 && grade <= 12)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.09f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.09f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.09f);
                if (grade == 12)
                {
                    upgradeSuccessRate = 40;
                }
            }
            else if (grade>=13 && grade <= 16)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.1f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.1f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.1f);
                if (grade == 16)
                {
                    upgradeSuccessRate = 10;
                }
            }
            else if (grade>=17 && grade <= 19)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.15f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.15f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.15f);
                if (grade == 19)
                {
                    upgradeSuccessRate = 5;
                }
            }
            else if (grade == 20)
            {
                statsBasicArm.defense += (statsBasicArm.defense* 0.25f);
                statsBasicArm.durabilityCap += (statsBasicArm.durabilityCap* 0.25f);
                statsBasicArm.movementSpeed += (statsBasicArm.movementSpeed* 0.25f);
                upgradeSuccessRate = 0;
            }
    */