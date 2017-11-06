using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUI : MonoBehaviour {

    public GUIText strengthText;
    public PlayerBase playerStat;

	// Use this for initialization
	void Start ()
    {
        UpdateText();	
	}
	
    public void UpdateText()
    {
        strengthText.text = Mathf.RoundToInt(playerStat.atributes.strength).ToString();
    }
	
}
