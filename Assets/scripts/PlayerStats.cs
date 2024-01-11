using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats{
    public int level = 1;
    public int xpRequired = 10;//150;
    public int currXp = 0;
    public float currHealth = 100f;
    public int mobsKilled = 0;
    public ClassSpecs activeClass;
    //Upgradable stats
    public float damageMultiplier = 1f;
    public float speed = 1f; //Active factor but baseline comes from ship stats
    public float attackSpeed = 1f;
    public float maxHealth = 100f;
    public float critChance = 0.1f; //Not implemented
    public float critDamageMultiplier = 1.5f; //Not implemented
    LevelUpHandler lvlUp;
    public (string, float, float)[] upgradesAll;
    public void levelUp(){
        level++;
        currXp = currXp-xpRequired;
        xpRequired = (int)((xpRequired + 10) * 1.1f);
        lvlUp = GameObject.Find("Canvas").GetComponent<LevelUpHandler>();
        //Prob convert to tuples to display proper names in UI
        (string, float, float)[] upgradesAll = {("Damage Increase +5%", damageMultiplier, damageMultiplier*1.05f), ("Rocket Speed +5%", speed, speed*1.05f), ("Attack Speed +5%", attackSpeed, attackSpeed*1.05f), ("Maximum Health +15", maxHealth, maxHealth+25), ("Critical Chance +7%",critChance, critChance*1.07f), ("Critical Damage +10%", critDamageMultiplier, critDamageMultiplier*1.1f)};
        string[] upgrades = {upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)].Item1, upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)].Item1, upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)].Item1};
        //Select 1 of 3, increase stat
        lvlUp.InitiateLevelUp(upgrades);
    }
    public void IncreaseStat(string toolTip){
        if (toolTip.Equals("Damage Increase +5%")){
            damageMultiplier += 0.05f;
        }else if (toolTip.Equals("Rocket Speed +5%")){
            speed += 0.05f;
        }else if (toolTip.Equals("Attack Speed +5%")){
            attackSpeed += 0.05f;
        }else if (toolTip.Equals("Maximum Health +15")){
            maxHealth += 15;
            currHealth += 15;
        }else if (toolTip.Equals("Critical Chance +7%")){
            critChance += 0.07f;
        }else if (toolTip.Equals("Critical Damage +10%")){
            critDamageMultiplier += 0.1f;
        }
    }


    public void gainXp(int amount){
        currXp += amount;
        if (currXp >= xpRequired){
            levelUp();
        }
    }

}