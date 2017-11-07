using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthUI : MonoBehaviour {

    public Text nameText;
    public Text classhText;
    public Text levelText;
    public Text expText;
    public Text atributsPointsText;
    public Text strengthText;
    public Text dexterityText;
    public Text vitalityText;
    public Text energyText;
    public Text goldText;
    public PlayerBase player;

	// Use this for initialization
	void Start ()
    {
        UpdateText();	
	}
	
    public void UpdateText()
    {
        nameText.text = player.name;
        classhText.text = player.kind.ToString();
        levelText.text = Mathf.RoundToInt(player.lvl).ToString();
        expText.text = Mathf.RoundToInt(player.xp).ToString();
        atributsPointsText.text = Mathf.RoundToInt(player.atributesPoint).ToString();
        strengthText.text = Mathf.RoundToInt(player.atributes.strength).ToString();
        dexterityText.text = Mathf.RoundToInt(player.atributes.dexterity).ToString();
        vitalityText.text = Mathf.RoundToInt(player.atributes.vitality).ToString();
        energyText.text = Mathf.RoundToInt(player.atributes.energy).ToString();
        goldText.text = Mathf.RoundToInt(player.money).ToString();
    }

    private void Update()
    {
        UpdateText();
    }
}
