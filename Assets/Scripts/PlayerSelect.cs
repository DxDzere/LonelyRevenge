using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    int posicionPLayerBase = 0;
    PlayerBase player = new PlayerBase();
    JSONLoader functions;

    private void Start()
    {
        player = functions.ReturnPlayerBase(posicionPLayerBase, player);
    }

    public void RightButton()
    {
        if (posicionPLayerBase == 5)
        {
            posicionPLayerBase = 0;
        }
        else
        {
            posicionPLayerBase++;
        }

        player = functions.ReturnPlayerBase(posicionPLayerBase, player);
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

        player = functions.ReturnPlayerBase(posicionPLayerBase, player);
    }

    public void SelectBotton()
    {
        string characterPlayer = JsonUtility.ToJson(player, true);
        Debug.Log(characterPlayer);
    }
}