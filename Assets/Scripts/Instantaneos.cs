using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantaneos : Consumibles{

	enum itemsInstantaneos {antidoto, pergaminoTeleport, elixirVida, elixirMana}
    public changeState states;

    public struct changeState
    {
        float mana;
        float vida;
        Vector3 position;
        bool state;
    }
}
