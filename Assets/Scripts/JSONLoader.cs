using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JSONLoader : MonoBehaviour {

    PlayerBase[] playerArray;
    PlayerBase[] players;
    Items[] itemsArray;
    Arma[] armasArray;
    Armadura[] armadurasArray;

    private void Start()
    {
        
    }

    private string LoadText(string _path)
    {
        string text = string.Empty;
        text = File.ReadAllText(_path);
        return text;
    }

    private PlayerBase [] LoadJsonPersonaje(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int playerCount = jsonObjAux.GetField("Personaje").Count;
        playerArray = new PlayerBase[playerCount];

        for (int i =0; i < jsonObjAux.GetField("Personaje").Count; i++)
        {
            jsonObjAux = jsonObj;
            playerArray[i].name = (jsonObj.HasField("name")) ? jsonObj.GetField("name").str : string.Empty;
            playerArray[i].description = (jsonObj.HasField("Description")) ? jsonObj.GetField("Description").str : string.Empty;
            //playerArray[i].kind = (jsonObj.HasField("Kind")) ? jsonObj.GetField("Kind").str : string.Empty;

            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                playerArray[i].stats.healthCap = (jsonObj.HasField("HealthCap")) ? jsonObjAux[i].GetField("HealthCap").n : 0;
                playerArray[i].stats.strength = (jsonObj.HasField("Strength")) ? jsonObjAux[i].GetField("Strength").n : 0;
                playerArray[i].stats.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                playerArray[i].stats.manaCap = (jsonObj.HasField("ManaCap")) ? jsonObjAux[i].GetField("ManaCap").n : 0;
                playerArray[i].stats.dexterity = (jsonObj.HasField("Dexterity")) ? jsonObjAux[i].GetField("Dexterity").n : 0;
            }
        }

        return playerArray;
    }

    private Items[] LoadJsonItems(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int itemsCount = jsonObjAux.GetField("Items").Count;
        itemsArray = new Items[itemsCount];

        for (int i = 0; i < jsonObjAux.GetField("Items").Count; i++)
        {
            jsonObjAux = jsonObj;
            itemsArray[i].name = (jsonObj.HasField("name")) ? jsonObj.GetField("name").str : string.Empty;
            itemsArray[i].description = (jsonObj.HasField("Description")) ? jsonObj.GetField("Description").str : string.Empty;
        }

        return itemsArray;
    }

    private Arma[] LoadJsonArmas(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int armasCount = jsonObjAux.GetField("armas").Count;
        armasArray = new Arma[armasCount];

        for (int i = 0; i < jsonObjAux.GetField("armas").Count; i++)
        {
            jsonObjAux = jsonObj;
            armasArray[i].name = (jsonObj.HasField("name")) ? jsonObj.GetField("name").str : string.Empty;
            armasArray[i].description = (jsonObj.HasField("Description")) ? jsonObj.GetField("Description").str : string.Empty;
            armasArray[i].lvl = (jsonObj.HasField("Level")) ? jsonObj.GetField("Level").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armasArray[i].statsBasicA.attack = (jsonObj.HasField("Attack")) ? jsonObjAux[i].GetField("Attack").n : 0;
                armasArray[i].statsBasicA.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armasArray[i].statsBasicA.dexterity = (jsonObj.HasField("Dexterity")) ? jsonObjAux[i].GetField("Dexterity").n : 0;
            }
        }

        return armasArray;
    }

    private Armadura[] LoadJsonArmadura(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int armasCount = jsonObjAux.GetField("armas").Count;
        armasArray = new Arma[armasCount];

        for (int i = 0; i < jsonObjAux.GetField("armas").Count; i++)
        {
            jsonObjAux = jsonObj;
            armadurasArray[i].name = (jsonObj.HasField("name")) ? jsonObj.GetField("name").str : string.Empty;
            armadurasArray[i].description = (jsonObj.HasField("Description")) ? jsonObj.GetField("Description").str : string.Empty;
            armadurasArray[i].lvl = (jsonObj.HasField("Level")) ? jsonObj.GetField("Level").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armadurasArray[i].statsBasicArm.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armadurasArray[i].statsBasicArm.dexterity = (jsonObj.HasField("Dexterity")) ? jsonObjAux[i].GetField("Dexterity").n : 0;
            }
        }

        return armadurasArray;
    }
}
