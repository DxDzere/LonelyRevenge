using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automaticos : Consumibles{

    enum pociones {pocionVida, pocionMana}
    public typeRecarga statsRecarga;

    public struct typeRecarga
    {
        int health;
        int mana;
    }
}
