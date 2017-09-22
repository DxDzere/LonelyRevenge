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
        string jsonPlayers = LoadText("Personajes.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);

        string jsonItems = LoadText("Items.txt");
        itemsArray = LoadJsonItems(jsonItems);

        string jsonArmas = LoadText("Armas.txt");
        itemsArray = LoadJsonItems(jsonItems);

        string jsonArmaduras = LoadText("Armaduras.txt");
        itemsArray = LoadJsonItems(jsonItems);
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
        Debug.Log(jsonObjAux);
        int playerCount = jsonObjAux.GetField("Personajes").Count;
        Debug.Log(playerCount);
        playerArray = new PlayerBase[playerCount];

        for (int i = 0; i < playerCount; i++)
        {
            jsonObjAux = jsonObj.GetField("Personajes");
            Debug.Log(jsonObjAux);
            playerArray[i] = new PlayerBase();
            playerArray[i].name = (jsonObjAux[i].HasField("name")) ? jsonObjAux[i].GetField("name").str : string.Empty;
            playerArray[i].description = (jsonObjAux[i].HasField("descripcion")) ? jsonObjAux[i].GetField("descripcion").str : string.Empty;
            playerArray[i].kind = (jsonObjAux[i].HasField("Kind")) ? (CharacterBasic.characterType)System.Enum.Parse(typeof(CharacterBasic.characterType), jsonObjAux[i].GetField("Kind").str) : CharacterBasic.characterType.Default;
            playerArray[i].money = (jsonObjAux.HasField("Money")) ? jsonObjAux.GetField("Money").n : 0;

            Debug.Log(playerArray[i].name);
            Debug.Log(playerArray[i].description);

            if (jsonObjAux[i].HasField("Stats"))
            {
                jsonObjAux = jsonObjAux[i].GetField("Stats");
                playerArray[i].playerBaseStats.physicalDamage = (jsonObjAux.HasField("PhysicalDamage")) ? jsonObjAux.GetField("PhysicalDamage").n : 0;
                playerArray[i].playerBaseStats.abilityDamage = (jsonObjAux.HasField("HabilityDamage")) ? jsonObjAux.GetField("HabilityDamage").n : 0;
                playerArray[i].playerBaseStats.defense = (jsonObjAux.HasField("Defense")) ? jsonObjAux.GetField("Defense").n : 0;
                playerArray[i].playerBaseStats.attackSpeed = (jsonObjAux.HasField("AttackSpeed")) ? jsonObjAux.GetField("AttackSpeed").n : 0;
                playerArray[i].playerBaseStats.movementSpeed = (jsonObjAux.HasField("MovementSpeed")) ? jsonObjAux.GetField("MovementSpeed").n : 0;
                playerArray[i].playerBaseStats.healthCap = (jsonObjAux.HasField("HealthCap")) ? jsonObjAux.GetField("HealthCap").n : 0;
                playerArray[i].playerBaseStats.manaCap = (jsonObjAux.HasField("ManaCap")) ? jsonObjAux.GetField("ManaCap").n : 0;
                playerArray[i].playerBaseStats.staminaCap = (jsonObjAux.HasField("StaminaCap")) ? jsonObjAux.GetField("StaminaCap").n : 0;
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

        for (int i = 0; i < itemsCount; i++)
        {
            jsonObjAux = jsonObj;
            itemsArray[i].name = (jsonObjAux[i].GetField("name")) ? jsonObjAux[i].GetField("name").str : string.Empty;
            itemsArray[i].description = (jsonObjAux[i].GetField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            itemsArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            itemsArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
        }

        return itemsArray;
    }

    private Arma[] LoadJsonArmas(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int armasCount = jsonObjAux.GetField("Armas").Count;
        armasArray = new Arma[armasCount];

        for (int i = 0; i < armasCount; i++)
        {
            jsonObjAux = jsonObj;
            armasArray[i].name = (jsonObjAux[i].HasField("name")) ? jsonObjAux[i].GetField("name").str : string.Empty;
            armasArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            armasArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            armasArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
            armasArray[i].priceRepair = (jsonObjAux[i].HasField("PriceRepair")) ? jsonObjAux[i].GetField("PriceRepair").n : 0;
            armasArray[i].priceUpgrade = (jsonObjAux[i].HasField("PriceUpgrade")) ? jsonObjAux[i].GetField("PriceUpgrade").n : 0;
            armasArray[i].grade = (jsonObjAux[i].HasField("Grade")) ? jsonObjAux[i].GetField("Grade").n : 0;
            armasArray[i].upgradeSuccessRate = (jsonObjAux[i].HasField("UpgradeSuccessRate")) ? jsonObjAux[i].GetField("UpgradeSuccessRate").n : 0;
            armasArray[i].lvl = (jsonObjAux[i].HasField("Level")) ? jsonObjAux[i].GetField("Level").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armasArray[i].statsBasicA.pAttackMin = (jsonObj.HasField("P. AtaqueMin")) ? jsonObjAux[i].GetField("P. AtaqueMin").n : 0;
                armasArray[i].statsBasicA.pAttackMax = (jsonObj.HasField("P. AtaqueMax")) ? jsonObjAux[i].GetField("P. AtaqueMax").n : 0;
                armasArray[i].statsBasicA.aAttackMin = (jsonObj.HasField("A. AtaqueMin")) ? jsonObjAux[i].GetField("A. AtaqueMin").n : 0;
                armasArray[i].statsBasicA.aAttackMax = (jsonObj.HasField("A. AtaqueMax")) ? jsonObjAux[i].GetField("A. AtaqueMax").n : 0;
                armasArray[i].statsBasicA.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armasArray[i].statsBasicA.attackSpeed = (jsonObj.HasField("AttackSpeed")) ? jsonObjAux[i].GetField("AttackSpeed").n : 0;
                armasArray[i].statsBasicA.movementSpeed = (jsonObj.HasField("MovementSpeed")) ? jsonObjAux[i].GetField("MovementSpeed").n : 0;
            }
        }

        return armasArray;
    }

    private Armadura[] LoadJsonArmadura(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int armadurasCount = jsonObjAux.GetField("Armaduras").Count;
        armadurasArray = new Armadura[armadurasCount];

        for (int i = 0; i < armadurasCount; i++)
        {
            jsonObjAux = jsonObj;
            armadurasArray[i].name = (jsonObjAux[i].HasField("name")) ? jsonObjAux[i].GetField("name").str : string.Empty;
            armadurasArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            armadurasArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            armadurasArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
            armadurasArray[i].priceRepair = (jsonObjAux[i].HasField("PriceRepair")) ? jsonObjAux[i].GetField("PriceRepair").n : 0;
            armadurasArray[i].priceUpgrade = (jsonObjAux[i].HasField("PriceUpgrade")) ? jsonObjAux[i].GetField("PriceUpgrade").n : 0;
            armadurasArray[i].grade = (jsonObjAux[i].HasField("Grade")) ? jsonObjAux[i].GetField("Grade").n : 0;
            armadurasArray[i].upgradeSuccessRate = (jsonObjAux[i].HasField("UpgradeSuccessRate")) ? jsonObjAux[i].GetField("UpgradeSuccessRate").n : 0;
            armadurasArray[i].lvl = (jsonObjAux[i].HasField("Level")) ? jsonObjAux[i].GetField("Level").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armadurasArray[i].statsBasicArm.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armadurasArray[i].statsBasicArm.movementSpeed = (jsonObj.HasField("MovementSpeed")) ? jsonObjAux[i].GetField("MovementSpeed").n : 0;
                armadurasArray[i].statsBasicArm.durabilityCap = (jsonObj.HasField("Durabilidad")) ? jsonObjAux[i].GetField("Durabilidad").n : 0;
            }
        }

        return armadurasArray;
    }
}
