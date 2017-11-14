using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JSONLoader : MonoBehaviour {


    public PlayerBase[] playerArray;
    public EnemyBase[] enemyArray;
    public Consumibles[] consArray;
    public Arma[] armasArray;
    public Armadura[] armadurasArray;
    public Joyeria[] joyeriaArray;
    public Quest[] questArray;
    public Objetivo[] objetivoArray;
    public Reward[] rewardArray;
    public Dialog[] dialogArray;
    public Sentences[] sentencesArray;

    private void Awake()
    {
        string jsonPlayers = LoadText("Personajes.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);
		
        string jsonEnemys = LoadText("Enemys.txt");
        enemyArray = LoadJsonEnemy(jsonEnemys);

        string jsonConsumibles = LoadText("Consumibles.txt");
		consArray = LoadJsonCons(jsonConsumibles);

        string jsonArmas = LoadText("Armas.txt");
		armasArray = LoadJsonArmas(jsonArmas);

        string jsonArmaduras = LoadText("Armaduras.txt");
		armadurasArray = LoadJsonArmadura(jsonArmaduras);
		
        string jsonJoyeria = LoadText("Joyeria.txt");
        joyeriaArray = LoadJsonJoyeria(jsonJoyeria);

        /*string jsonQuest = LoadText("Quest.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);

        string jsonObjetivo = LoadText("Objetivo.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);

        string jsonReward = LoadText("Reward.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);

        string jsonDialog = LoadText("Dialog.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);

        string jsonSentences = LoadText("Sentences.txt");
        playerArray = LoadJsonPersonaje(jsonPlayers);*/
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
            playerArray[i].name = (jsonObjAux[i].HasField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            playerArray[i].description = (jsonObjAux[i].HasField("Descripcion")) ? jsonObjAux[i].GetField("Descripcion").str : string.Empty;
            playerArray[i].kind = (jsonObjAux[i].HasField("Kind")) ? (PlayerBase.characterType)System.Enum.Parse(typeof(PlayerBase.characterType), jsonObjAux[i].GetField("Kind").str) : PlayerBase.characterType.Default;
            playerArray[i].money = (jsonObjAux.HasField("Money")) ? jsonObjAux.GetField("Money").n : 0;
            playerArray[i].xp = (jsonObjAux.HasField("Xp")) ? jsonObjAux.GetField("Xp").n : 0;
            playerArray[i].xpCap = (jsonObjAux.HasField("XpCap")) ? jsonObjAux.GetField("XpCap").n : 500;
            playerArray[i].lvl = (jsonObjAux.HasField("Lvl")) ? jsonObjAux.GetField("Lvl").n : 1;
            playerArray[i].lvlCap = (jsonObjAux.HasField("LvlCap")) ? jsonObjAux.GetField("LvlCap").n : 100;
            playerArray[i].atributesPoint = (jsonObjAux.HasField("AtributesPoint")) ? jsonObjAux.GetField("AtributesPoint").n : 0;

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
            if (jsonObjAux[i].HasField("Atributes"))
            {
                jsonObjAux = jsonObjAux[i].GetField("Atributes");
                playerArray[i].atributes.strength = (jsonObjAux.HasField("Strength")) ? jsonObjAux.GetField("Strength").n : 1;
                playerArray[i].atributes.vitality = (jsonObjAux.HasField("Vitality")) ? jsonObjAux.GetField("Vitality").n : 1;
                playerArray[i].atributes.dexterity = (jsonObjAux.HasField("Dexterity")) ? jsonObjAux.GetField("Dexterity").n : 1;
                playerArray[i].atributes.energy = (jsonObjAux.HasField("Energy")) ? jsonObjAux.GetField("Energy").n : 1;
                playerArray[i].atributes.strengthCap = (jsonObjAux.HasField("StrengthCap")) ? jsonObjAux.GetField("StrengthCap").n : 150;
                playerArray[i].atributes.vitalityCap = (jsonObjAux.HasField("VitalityCap")) ? jsonObjAux.GetField("VitalityCap").n : 150;
                playerArray[i].atributes.dexterityCap = (jsonObjAux.HasField("DexterityCap")) ? jsonObjAux.GetField("DexterityCap").n : 150;
                playerArray[i].atributes.energyCap = (jsonObjAux.HasField("EnergyCap")) ? jsonObjAux.GetField("EnergyCap").n : 150;
            }
        }

        return playerArray;
    }

    private EnemyBase [] LoadJsonEnemy(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        Debug.Log(jsonObjAux);
        int enemyCount = jsonObjAux.GetField("Enemy").Count;
        Debug.Log(enemyCount);
        enemyArray = new EnemyBase[enemyCount];

        for (int i = 0; i < enemyCount; i++)
        {
            jsonObjAux = jsonObj.GetField("Enemy");
            Debug.Log(jsonObjAux);
            enemyArray[i] = new EnemyBase();
            enemyArray[i].name = (jsonObjAux[i].HasField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            enemyArray[i].description = (jsonObjAux[i].HasField("Descripcion")) ? jsonObjAux[i].GetField("Descripcion").str : string.Empty;
            enemyArray[i].classEnemy = (jsonObjAux[i].HasField("Class")) ? (EnemyBase.enemyType)System.Enum.Parse(typeof(EnemyBase.enemyType), jsonObjAux[i].GetField("Class").str) : EnemyBase.enemyType.Default;
            enemyArray[i].money = (jsonObjAux.HasField("Money")) ? jsonObjAux.GetField("Money").n : 0;

            if (jsonObjAux[i].HasField("Stats"))
            {
                jsonObjAux = jsonObjAux[i].GetField("Stats");
                enemyArray[i].playerBaseStats.physicalDamage = (jsonObjAux.HasField("PhysicalDamage")) ? jsonObjAux.GetField("PhysicalDamage").n : 0;
                enemyArray[i].playerBaseStats.abilityDamage = (jsonObjAux.HasField("HabilityDamage")) ? jsonObjAux.GetField("HabilityDamage").n : 0;
                enemyArray[i].playerBaseStats.defense = (jsonObjAux.HasField("Defense")) ? jsonObjAux.GetField("Defense").n : 0;
                enemyArray[i].playerBaseStats.attackSpeed = (jsonObjAux.HasField("AttackSpeed")) ? jsonObjAux.GetField("AttackSpeed").n : 0;
                enemyArray[i].playerBaseStats.movementSpeed = (jsonObjAux.HasField("MovementSpeed")) ? jsonObjAux.GetField("MovementSpeed").n : 0;
                enemyArray[i].playerBaseStats.healthCap = (jsonObjAux.HasField("HealthCap")) ? jsonObjAux.GetField("HealthCap").n : 0;
                enemyArray[i].playerBaseStats.manaCap = (jsonObjAux.HasField("ManaCap")) ? jsonObjAux.GetField("ManaCap").n : 0;
                enemyArray[i].playerBaseStats.staminaCap = (jsonObjAux.HasField("StaminaCap")) ? jsonObjAux.GetField("StaminaCap").n : 0;
            }
        }

        return enemyArray;
    }

    private Consumibles[] LoadJsonCons(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int consCount = jsonObjAux.GetField("Consumibles").Count;
        consArray = new Consumibles[consCount];

        for (int i = 0; i < consCount; i++)
		{
			jsonObjAux = jsonObj.GetField ("Consumibles");
			consArray[i] = new Consumibles();
            consArray[i].itemName = (jsonObjAux[i].GetField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            consArray[i].description = (jsonObjAux[i].GetField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            consArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            consArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
			consArray[i].ID = (jsonObjAux[i].HasField("ID")) ? jsonObjAux[i].GetField("ID").n : 0;
            consArray[i].time = (jsonObjAux[i].HasField("Time")) ? jsonObjAux[i].GetField("Time").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                consArray[i].statsBase.healthCap = (jsonObjAux.HasField("HealthCap")) ? jsonObjAux.GetField("HealthCap").n : 0;
                consArray[i].statsBase.manaCap = (jsonObjAux.HasField("ManaCap")) ? jsonObjAux.GetField("ManaCap").n : 0;
                consArray[i].statsBase.health = (jsonObjAux.HasField("Health")) ? jsonObjAux.GetField("Health").n : 0;
                consArray[i].statsBase.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                consArray[i].statsBase.mana = (jsonObjAux.HasField("Mana")) ? jsonObjAux.GetField("Mana").n : 0;
                consArray[i].statsBase.stamina = (jsonObjAux.HasField("Stamina")) ? jsonObjAux.GetField("Stamina").n : 0;
                consArray[i].statsBase.attackSpeed = (jsonObjAux.HasField("AttackSpeed")) ? jsonObjAux.GetField("AttackSpeed").n : 0;
                consArray[i].statsBase.movementSpeed = (jsonObjAux.HasField("MovementSpeed")) ? jsonObjAux.GetField("MovementSpeed").n : 0;
                consArray[i].statsBase.attack = (jsonObjAux.HasField("Attack")) ? jsonObjAux.GetField("Attack").n : 0;
            }
        }

        return consArray;
    }

    private Arma[] LoadJsonArmas(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
		int armasCount = 0;
		if (jsonObjAux.HasField ("Armas")) 
		{
			armasCount = jsonObjAux.GetField ("Armas").Count;
		}
        armasArray = new Arma[armasCount];

        for (int i = 0; i < armasCount; i++)
        {
			jsonObjAux = jsonObj.GetField ("Armas");
			armasArray [i] = new Arma ();

			armasArray[i].itemName = (jsonObjAux[i].HasField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            armasArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            armasArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            armasArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
            armasArray[i].priceRepair = (jsonObjAux[i].HasField("PriceRepair")) ? jsonObjAux[i].GetField("PriceRepair").n : 0;
            armasArray[i].priceUpgrade = (jsonObjAux[i].HasField("PriceUpgrade")) ? jsonObjAux[i].GetField("PriceUpgrade").n : 0;
            armasArray[i].grade = (jsonObjAux[i].HasField("Grade")) ? jsonObjAux[i].GetField("Grade").n : 0;
            armasArray[i].upgradeSuccessRate = (jsonObjAux[i].HasField("UpgradeSuccessRate")) ? jsonObjAux[i].GetField("UpgradeSuccessRate").n : 0;
			armasArray[i].lvl = (jsonObjAux[i].HasField("Level")) ? jsonObjAux[i].GetField("Level").n : 0;
			armasArray[i].ID = (jsonObjAux[i].HasField("ID")) ? jsonObjAux[i].GetField("ID").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armasArray[i].statsBasicA.pAttackMin = (jsonObj.HasField("P.AttackMin")) ? jsonObjAux[i].GetField("P.AttackMin").n : 0;
                armasArray[i].statsBasicA.pAttackMax = (jsonObj.HasField("P.AttackMax")) ? jsonObjAux[i].GetField("P.AttackMax").n : 0;
                armasArray[i].statsBasicA.aAttackMin = (jsonObj.HasField("A.AttackMin")) ? jsonObjAux[i].GetField("A.AttackMin").n : 0;
                armasArray[i].statsBasicA.aAttackMax = (jsonObj.HasField("A.AttackMax")) ? jsonObjAux[i].GetField("A.AttackMax").n : 0;
                armasArray[i].statsBasicA.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armasArray[i].statsBasicA.attackSpeed = (jsonObj.HasField("AttackSpeed")) ? jsonObjAux[i].GetField("AttackSpeed").n : 0;
                armasArray[i].statsBasicA.movementSpeed = (jsonObj.HasField("MovementSpeed")) ? jsonObjAux[i].GetField("MovementSpeed").n : 0;
                playerArray[i].playerBaseStats.healthCap = (jsonObjAux.HasField("HealthCap")) ? jsonObjAux.GetField("HealthCap").n : 0;
                playerArray[i].playerBaseStats.manaCap = (jsonObjAux.HasField("ManaCap")) ? jsonObjAux.GetField("ManaCap").n : 0;
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
			jsonObjAux = jsonObj.GetField ("Armaduras");
			armadurasArray [i] = new Armadura ();

            armadurasArray[i].itemName = (jsonObjAux[i].HasField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            armadurasArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            armadurasArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            armadurasArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
            armadurasArray[i].priceRepair = (jsonObjAux[i].HasField("PriceRepair")) ? jsonObjAux[i].GetField("PriceRepair").n : 0;
            armadurasArray[i].priceUpgrade = (jsonObjAux[i].HasField("PriceUpgrade")) ? jsonObjAux[i].GetField("PriceUpgrade").n : 0;
            armadurasArray[i].grade = (jsonObjAux[i].HasField("Grade")) ? jsonObjAux[i].GetField("Grade").n : 0;
            armadurasArray[i].upgradeSuccessRate = (jsonObjAux[i].HasField("UpgradeSuccessRate")) ? jsonObjAux[i].GetField("UpgradeSuccessRate").n : 0;
			armadurasArray[i].lvl = (jsonObjAux[i].HasField("Level")) ? jsonObjAux[i].GetField("Level").n : 0;
			armadurasArray[i].ID = (jsonObjAux[i].HasField("ID")) ? jsonObjAux[i].GetField("ID").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                armadurasArray[i].statsBasicArm.defense = (jsonObj.HasField("Defense")) ? jsonObjAux[i].GetField("Defense").n : 0;
                armadurasArray[i].statsBasicArm.movementSpeed = (jsonObj.HasField("MovementSpeed")) ? jsonObjAux[i].GetField("MovementSpeed").n : 0;
                armadurasArray[i].statsBasicArm.durabilityCap = (jsonObj.HasField("Durability")) ? jsonObjAux[i].GetField("Duravility").n : 0;
            }
        }

        return armadurasArray;
    }
	
	private Joyeria[] LoadJsonJoyeria(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int joyeriaCount = jsonObjAux.GetField("Joyeria").Count;
        joyeriaArray = new Joyeria[joyeriaCount];

        for (int i = 0; i < joyeriaCount; i++)
		{
			jsonObjAux = jsonObj.GetField ("Joyeria");
			joyeriaArray[i] = new Joyeria();

            joyeriaArray[i].itemName = (jsonObjAux[i].HasField("Name")) ? jsonObjAux[i].GetField("Name").str : string.Empty;
            joyeriaArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            joyeriaArray[i].priceSell = (jsonObjAux[i].HasField("PriceSell")) ? jsonObjAux[i].GetField("PriceSell").n : 0;
            joyeriaArray[i].priceBuy = (jsonObjAux[i].HasField("PriceBuy")) ? jsonObjAux[i].GetField("PriceBuy").n : 0;
            joyeriaArray[i].priceRepair = (jsonObjAux[i].HasField("PriceRepair")) ? jsonObjAux[i].GetField("PriceRepair").n : 0;
            joyeriaArray[i].priceUpgrade = (jsonObjAux[i].HasField("PriceUpgrade")) ? jsonObjAux[i].GetField("PriceUpgrade").n : 0;
            joyeriaArray[i].grade = (jsonObjAux[i].HasField("Grade")) ? jsonObjAux[i].GetField("Grade").n : 0;
            joyeriaArray[i].upgradeSuccessRate = (jsonObjAux[i].HasField("UpgradeSuccessRate")) ? jsonObjAux[i].GetField("UpgradeSuccessRate").n : 0;
			joyeriaArray[i].lvl = (jsonObjAux[i].HasField("Level")) ? jsonObjAux[i].GetField("Level").n : 0;
			joyeriaArray[i].ID = (jsonObjAux[i].HasField("ID")) ? jsonObjAux[i].GetField("ID").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObj = jsonObj.GetField("Stat");
                joyeriaArray[i].stats.healthCap = (jsonObjAux.HasField("HealthCap")) ? jsonObjAux.GetField("HealthCap").n : 0;
                joyeriaArray[i].stats.manaCap = (jsonObjAux.HasField("ManaCap")) ? jsonObjAux.GetField("ManaCap").n : 0;
                joyeriaArray[i].stats.staminaCap = (jsonObjAux.HasField("StaminaCap")) ? jsonObjAux.GetField("StaminaCap").n : 0;
                joyeriaArray[i].stats.attackSpeed = (jsonObjAux.HasField("AttackSpeed")) ? jsonObjAux.GetField("AttackSpeed").n : 0;
                joyeriaArray[i].stats.movementSpeed = (jsonObjAux.HasField("MovementSpeed")) ? jsonObjAux.GetField("MovementSpeed").n : 0;
            }
        }

        return joyeriaArray;
    }

    private Quest[] LoadJsonQuest(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int questCount = jsonObjAux.GetField("Quest").Count;
        questArray = new Quest[questCount];

        for (int i = 0; i < questCount; i++)
        {
            jsonObjAux = jsonObj.GetField("Quest");
            questArray[i] = new Quest();
            questArray[i].description = (jsonObjAux[i].HasField("Description")) ? jsonObjAux[i].GetField("Description").str : string.Empty;
            questArray[i].ID = (jsonObjAux[i].HasField("ID")) ? jsonObjAux[i].GetField("ID").n : 0;
            questArray[i].sideQuest = (jsonObjAux[i].HasField("SideQuest")) ? jsonObjAux[i].GetField("SideQuest").n : 0;
            questArray[i].nextQuest = (jsonObjAux[i].HasField("NextQuest")) ? jsonObjAux[i].GetField("NextQuest").n : 0;

        }

        return questArray;
    }

   private Reward[] LoadJsonReward(string _json)
    {
        JSONObject jsonObj = new JSONObject(_json);
        JSONObject jsonObjAux = jsonObj;
        int rewardCount = jsonObjAux.GetField("Reward").Count;
        rewardArray = new Reward[rewardCount];

        for (int i = 0; i < rewardCount; i++)
        {
            jsonObjAux = jsonObj.GetField("Reward");
            rewardArray[i] = new Reward();
            rewardArray[i].xpReward = (jsonObjAux[i].HasField("xpReward")) ? jsonObjAux[i].GetField("xpReward").n : 0;
            rewardArray[i].moneyReward = (jsonObjAux[i].HasField("moneyReward")) ? jsonObjAux[i].GetField("moneyReward").n : 0;
            if (jsonObj.HasField("Stats"))
            {
                jsonObjAux = jsonObjAux.GetField("itemReward");
                rewardArray[i].itemReward = new float[jsonObjAux.Count];
                for(int j = 0; j < jsonObjAux.Count; j++)
                {
                    rewardArray[j].itemReward[j] = (jsonObjAux[j].n != null) ? jsonObjAux[j].n : 0;

                }
            }

        }

        return rewardArray;
    }

    public PlayerBase ReturnPlayerBase(int pos, PlayerBase playerReturn)
    {
        playerReturn.name = playerArray[pos].name;
        playerReturn.description = playerArray[pos].description;
        playerReturn.kind = playerArray[pos].kind;
        playerReturn.money = playerArray[pos].money;
        playerReturn.xp = playerArray[pos].xp;
        playerReturn.xpCap = playerArray[pos].xpCap;
        playerReturn.lvl = playerArray[pos].lvl;
        playerReturn.atributesPoint = playerArray[pos].atributesPoint;
        playerReturn.playerBaseStats.physicalDamage = playerArray[pos].playerBaseStats.physicalDamage;
        playerReturn.playerBaseStats.physicalDamage = playerArray[pos].playerBaseStats.physicalDamage;
        playerReturn.playerBaseStats.abilityDamage = playerArray[pos].playerBaseStats.abilityDamage;
        playerReturn.playerBaseStats.defense = playerArray[pos].playerBaseStats.defense;
        playerReturn.playerBaseStats.attackSpeed = playerArray[pos].playerBaseStats.attackSpeed;
        playerReturn.playerBaseStats.movementSpeed = playerArray[pos].playerBaseStats.movementSpeed;
        playerReturn.playerBaseStats.healthCap = playerArray[pos].playerBaseStats.healthCap;
        playerReturn.playerBaseStats.manaCap = playerArray[pos].playerBaseStats.manaCap;
        playerReturn.playerBaseStats.staminaCap = playerArray[pos].playerBaseStats.staminaCap;
        playerReturn.atributes.strength = playerArray[pos].atributes.strength;
        playerReturn.atributes.vitality = playerArray[pos].atributes.vitality;
        playerReturn.atributes.dexterity = playerArray[pos].atributes.dexterity;
        playerReturn.atributes.energy = playerArray[pos].atributes.energy;
        playerReturn.atributes.strengthCap = playerArray[pos].atributes.strengthCap;
        playerReturn.atributes.vitalityCap = playerArray[pos].atributes.vitalityCap;
        playerReturn.atributes.dexterityCap = playerArray[pos].atributes.dexterityCap;
        playerReturn.atributes.energyCap = playerArray[pos].atributes.energyCap;
        return playerReturn;
    }
}
