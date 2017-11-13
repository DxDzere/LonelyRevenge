using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    int posicionPLayerBase = 0;
    PlayerBase player;
    JSONLoader functions;

    private void Start()
    {
        functions.ReturnPlayerBase(posicionPLayerBase, player);
    }

    public void RightButton ()
    {
        if (posicionPLayerBase == 5)
        {
            posicionPLayerBase = 0;
        }
        else
        {
            posicionPLayerBase++;
        }

        functions.ReturnPlayerBase(posicionPLayerBase, player);
    }

    public void LeftBotton()
    {
        if (posicionPLayerBase == 0)
        {
            posicionPLayerBase = 5;
        }
        else
        {
            posicionPLayerBase--;
        }

        functions.ReturnPlayerBase(posicionPLayerBase, player);
    }

    public void SelectBotton()
    {
        
    }
}
