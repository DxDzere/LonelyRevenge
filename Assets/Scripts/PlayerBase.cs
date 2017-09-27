using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBasic
{
    [SerializeField]

    public playerAtributes atributes;
    public float money;
    public characterType kind;
	Inventario inv;
    
    public struct playerAtributes
    {
        public float strength;
        public float vitality;
        public float dexterity;
        public float energy;
    }
    //controller
    public float xp, xpCap, lvl, lvlCap, atributesPoint;
    public enum characterType {Warrior, SpellCaster, Rogue, Priest, Archer, Tamer, Default}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                inv.addItem(GameObject.FindWithTag("Item"));
            }
        }
    }
	
	public void levelUp()
	{
		lvl += 1;
        atributesPoint += 3;
		xpCap=xpCap*lvl;
		if (lvl == lvlCap)
		{
			xp=xpCap;
		}
		
	}
	
	/*public void atributsUp()
	{
		if (atributesPoint > 0)
		{
			switch (atributes)
			{
				case vitality:
					vitality +=1;
					healthCap = healthCap*vitality;
					defense = defense*vitality;
				break;
				case strength:
					strength +=1;
					physicalDamage = physicalDamage*strength;
					abilityDamage = abilityDamage*strength;
				break;
				case dexterity:
					dexterity +=1;
					attackSpeed = attackSpeed*dexterity;
					movementSpeed = movementSpeed*dexterity;
				break;
				case energy:
					energy +=1;
					staminaCap = staminaCap*energy;
					manaCap = manaCap*energy;
				break;
			}
		}
	}*/
	
	public void expUp(float xpEarned)
	{
		xp += xpEarned;
		while(xp>=xpCap)
		{
            xp -= xpCap;
			levelUp();
		}
	}
}
