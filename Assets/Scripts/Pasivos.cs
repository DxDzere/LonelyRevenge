using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasivos : Consumibles {

	enum pocionesPasivas {pocionFuerza, pocionAgilidad, pocionDefensa, pocionVitalidad, pocionEnergia, posionInmunidad}

    struct baseStats
    {
        int health;
        int attack;
        int defense;
        int mana;
        int dexterity;
    }
}
