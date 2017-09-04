using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : Equipables {
    
    public string clase;
    public statsArma statsBasicA;

    public struct statsArma
    {
        public float defense;
        public float attack;
        public float dexterity;
    }
}
