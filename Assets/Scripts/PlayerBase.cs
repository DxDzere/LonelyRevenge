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
    
	void Start()
	{
		Items itemA = new Items ();
		Items itemB = new Pasivos ();
		Debug.Log("ITEM A: " + (itemA.GetType()).ToString());
		Debug.Log("ITEM B: " + (itemB.GetType()).ToString());
		Debug.Log ("ITEM A = PASIVO? :" + (itemA.GetType () == typeof(Pasivos)));
		Debug.Log("ITEM B = PASIVO? :" + (itemB.GetType() == typeof(Pasivos)));
	}

    public struct playerAtributes
    {
        public float strength;
        public float vitality;
        public float dexterity;
        public float energy;
        public float strengthCap;
        public float vitalityCap;
        public float dexterityCap;
        public float energyCap;
    }
    //controller
    public float xp, xpCap, lvl, lvlCap, atributesPoint;
    public enum characterType {Warrior, SpellCaster, Rogue, Priest, Archer, Tamer, Default}

    private void OnTriggerEnter(Collider other)
    {
        Items item;
        if(other.tag == "Item")
        {
            item = other.gameObject.GetComponent<Items>();
            if (item != null)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    inv.addItem(item);
                    Destroy(other.gameObject);
                }
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
            xpCap+= xpCap*0.5f;
            atributesPoint += 3;
        }
	}

    public void expUp(float xpEarned)
	{
		xp += xpEarned;
		while(xp>= xpCap && lvl < lvlCap)
		{
            xp -= xpCap;
			levelUp();
		}
	}

    public void vitalityUp()
	{
		if (atributesPoint > 0 && atributes.vitality < atributes.vitalityCap)
		{
            atributes.vitality += 1;
            atributesPoint -= 1;
            playerBaseStats.healthCap = playerBaseStats.healthCap * atributes.vitality;
            playerBaseStats.defense = playerBaseStats.defense * atributes.vitality;
        }
	}

    public void strengthUp()
    {
        if (atributesPoint > 0 && atributes.strength < atributes.strengthCap)
        {
            atributes.strength += 1;
            atributesPoint -= 1;
            playerBaseStats.physicalDamage = playerBaseStats.physicalDamage * atributes.strength;
            playerBaseStats.abilityDamage = playerBaseStats.abilityDamage * atributes.strength;
        }
    }

    public void dexterityUp()
    {
        if (atributesPoint > 0 && atributes.dexterity < atributes.dexterityCap)
        {
            atributes.dexterity += 1;
            atributesPoint -= 1;
            playerBaseStats.attackSpeed = playerBaseStats.attackSpeed * atributes.dexterity;
            playerBaseStats.movementSpeed = playerBaseStats.movementSpeed * atributes.dexterity;
        }
    }

    public void energyUp()
    {
        if (atributesPoint > 0 && atributes.energy<atributes.energyCap)
        {
            atributes.energy += 1;
            atributesPoint -= 1;
            playerBaseStats.staminaCap = playerBaseStats.staminaCap * atributes.energy;
            playerBaseStats.manaCap = playerBaseStats.manaCap * atributes.energy;
        }
    }
}
