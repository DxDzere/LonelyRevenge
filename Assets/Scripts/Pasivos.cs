using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasivos : Consumibles {

	enum pocionesPasivas {pocionFuerza, pocionAgilidad, pocionDefensa, pocionVitalidad, pocionEnergia, posionInmunidad}
    public baseStats statsBase;

    public struct baseStats
    {
        float health;
        float attack;
        float defense;
        float mana;
        float dexterity;
    }
}
