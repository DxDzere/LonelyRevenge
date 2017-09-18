using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour{

    public string name;
    public string description;

    public PlayerBase.playerStats stats;


    public virtual void Use(PlayerBase _player)
    {

    }

    public virtual void Throw()
    {

    }

    public virtual void Sell()
    {

    }

    public virtual void Equip(PlayerBase _player)
    {

    }

    public virtual void Upgrade()
    {

    }

    public virtual void Repair()
    {

    }
}