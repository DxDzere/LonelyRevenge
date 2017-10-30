using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : Equipables {
    
    public string clase;
    public statsArma statsBasicA;

    public struct statsArma
    {
        public float defense;
        public float pAttackMin;
        public float pAttackMax;
        public float aAttackMin;
        public float aAttackMax;
        public float attackSpeed;
        public float movementSpeed;
    }

    public override void Use(PlayerBase _player)
    {
        _player.playerBaseStats.defense += statsBasicA.defense;
        _player.playerBaseStats.physicalDamage += Random.Range(statsBasicA.pAttackMin, statsBasicA.pAttackMax);
        _player.playerBaseStats.abilityDamage += Random.Range(statsBasicA.aAttackMin, statsBasicA.aAttackMax);
        _player.playerBaseStats.movementSpeed += statsBasicA.movementSpeed;
        _player.playerBaseStats.attackSpeed += statsBasicA.attackSpeed;
    }

    public override void Throw()
    {
        
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
            statsBasicA.defense += (statsBasicA.defense*multiplicator);
            statsBasicA.attackSpeed += (statsBasicA.attackSpeed * multiplicator);
            statsBasicA.aAttackMin += (statsBasicA.aAttackMin * multiplicator);
            statsBasicA.aAttackMax += (statsBasicA.aAttackMax * multiplicator);
            statsBasicA.pAttackMax += (statsBasicA.pAttackMax * multiplicator);
            statsBasicA.pAttackMin += (statsBasicA.pAttackMin * multiplicator);
            statsBasicA.movementSpeed += (statsBasicA.movementSpeed * multiplicator);
        }
        _player.money -= priceUpgrade;
    }
}
