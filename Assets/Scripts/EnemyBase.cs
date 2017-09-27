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
    public float lvl, lvlCap;
    public enum enemyType {Draconianos, Araneos, Zefiros, AngelCaido, Grifos, Minotauros, Satiro, Default}
	
	/*
	Sistema nemesis
	{
		public void levelUp()
		{
			lvl += 1;
			atributsPoint += 3;
			if (lvl == lvlCap)
			{
				xp==xpCap;
			}
		
		}
	
		public void expUp(float xpEarned)
		{
			xp += xpEarned;
			if(xp>=xpCap)
			{
				xp -= xpCap
				levelUp();
			}
		}
	}
	*/
}
