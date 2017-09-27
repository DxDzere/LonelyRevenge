using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBasic
{
    [SerializeField]

    public float money;
    public enemyType classEnemy;
    //ia
    //quest
    //items drop
    //controller
    public float xp, xpCap, lvl, lvlCap;
    public enum enemyType { Draconianos, Araneos, Zefiros, AngelCaido, Grifos, Minotauros, Satiro, Default }

    public void levelUp()
    {
        lvl += 1;
        xpCap += xpCap * 0.5f;
        if (lvl == lvlCap)
        {
            xp = xpCap;
        }
        playerBaseStats.healthCap += statsUp();
        playerBaseStats.defense += statsUp();
        playerBaseStats.physicalDamage += statsUp();
        playerBaseStats.movementSpeed += statsUp()*0.05f;
        playerBaseStats.attackSpeed += statsUp()*0.05f;
    }

    public void expUp(float xpEarned)
    {
        xp += xpEarned;
        while (xp >= xpCap && lvl < lvlCap)
        {
            xp -= xpCap;
            levelUp();
        }
    }

    public float statsUp()
    {
        float stat = Random.Range(5f, 50f);
        return stat;
    }
}