using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats{
    LevelUpHandler lvlUp;
    public int level = 1;
    public int xpRequired = 50;//150;
    public int currXp = 0;
    public float currHealth = 100f;
    public int mobsKilled = 0;
    public ClassSpecs activeClass;
    //Upgradable stats
    public float damageMultiplier = 1f;
    public float speed = 1f; //Active factor but baseline comes from ship stats
    public float attackSpeed = 1f;
    public float maxHealth = 100f;
    public float critChance = 0.1f;
    public float critDamageMultiplier = 1.5f;
    public float healthRegen = 0.4f;
    public float bulletPenetration = 0f;
    public float currentPenetration = 0f;
    public void levelUp(){
        level++;
        currXp = currXp-xpRequired;
        xpRequired = (int)((xpRequired + 10) * 1.1f);
        lvlUp = GameObject.Find("Canvas").GetComponent<LevelUpHandler>();
        //Prob convert to tuples to display proper names in UI
        string[] upgradesAll = {"Damage Increase +5%", "Rocket Speed +5%", "Attack Speed +5%", "Maximum Health +15", "Critical Chance +7%", "Critical Damage +10%", "HPS +0.1", "Bullet penetration +10%"};
        string[] upgrades = {upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)], upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)], upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)]};
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
        }else if(toolTip.Equals("HPS +0.1")){
            healthRegen += 0.4f;
        }else if(toolTip.Equals("Bullet penetration +10%")){
            bulletPenetration += 0.1f;
        }
    }

    public void HealthPickup(float amount){
        currHealth += amount;
        if (currHealth > maxHealth){
            currHealth = maxHealth;
        }
    }

    public void GainHealth(){
        if (currHealth < maxHealth){
            currHealth += healthRegen;
            if (currHealth > maxHealth){
                currHealth = maxHealth;
            }
        }
        
    }

    public int GetPenetration(){
        currentPenetration -= (int)currentPenetration;
        currentPenetration += bulletPenetration;
        return (int)currentPenetration;
    }


    public void gainXp(int amount){
        currXp += amount;
        if (currXp >= xpRequired){
            levelUp();
        }
    }

}