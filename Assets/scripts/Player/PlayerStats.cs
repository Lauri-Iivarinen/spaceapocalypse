using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats{
    LevelUpHandler lvlUp;
    public int level = 1;
    public float xpRequired = 50f;//150;
    public float currXp = 0f;
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
    public float healthRegen = 4f;
    public float bulletPenetration = 0f;
    public float currentPenetration = 0f;
    public float damageReduction = 1f;
    public float xpMultiplier = 1f;
    public float extraLives = 0f;
    public float currencyGain = 1f;
    //Boost
    public float BOOSTCAP = 50f;
    public float currBoost = 50f;
    public bool usingBoost = false;
    private float boostDelay = 50;
    private float currentBoostDelay = 0;
    private float boosterRecharge = 0.1f;

    //Trackers
    public static int killCount = 0;

    public PlayerStats(){
        killCount = 0;
        damageMultiplier += PermanentStats.upgrades[0].currAmount;
        speed += PermanentStats.upgrades[4].currAmount;
        attackSpeed += PermanentStats.upgrades[6].currAmount;
        maxHealth *= PermanentStats.upgrades[1].currAmount;
        critChance += PermanentStats.upgrades[7].currAmount;
        critDamageMultiplier *= PermanentStats.upgrades[8].currAmount;
        boosterRecharge += PermanentStats.upgrades[9].currAmount;
        healthRegen += PermanentStats.upgrades[2].currAmount;
        bulletPenetration += PermanentStats.upgrades[12].currAmount;
        damageReduction += PermanentStats.upgrades[3].currAmount;
        xpMultiplier += PermanentStats.upgrades[5].currAmount;
        extraLives += PermanentStats.upgrades[11].currAmount;
        currencyGain = PermanentStats.upgrades[10].currAmount;
    }
    
    public void levelUp(){
        level++;
        currXp = currXp-xpRequired;
        xpRequired = (int)(xpRequired+15) * 1.1f;
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        pl.LevelUpAnim();
    }

    public void checkBoost(){

        if (Input.GetKey(KeyCode.Space) && currBoost > 0 && currentBoostDelay == 0)
        {
            if (!usingBoost)
            {
                usingBoost = true;
                speed = speed * 2;
            }
            currBoost--;
        }
        else if (usingBoost)
        {
            speed = speed / 2;
            usingBoost = false;
            currentBoostDelay = boostDelay;
        }
        else if (currBoost < BOOSTCAP) currBoost += boosterRecharge;

        if (currentBoostDelay > 0) currentBoostDelay--;
        
    }
    
    public void IncreaseStat(string toolTip){
        if (toolTip.Equals("Damage Increase +10%")){
            damageMultiplier *= 1.1f;
        }else if (toolTip.Equals("Rocket Speed +10%")){
            speed *= 1.1f;
        }else if (toolTip.Equals("Attack Speed +8%")){
            attackSpeed *= 1.08f;
        }else if (toolTip.Equals("Maximum Health +150")){
            maxHealth += 150;
            currHealth += 150;
        }else if (toolTip.Equals("Critical Chance +5%")){
            critChance += 0.05f;
        }else if (toolTip.Equals("Critical Damage +10%")){
            critDamageMultiplier *= 1.1f;
        }else if(toolTip.Equals("HPS +1")){
            healthRegen += 4f;
        }else if(toolTip.Equals("Bullet penetration +40%")){
            bulletPenetration += 0.4f;
        }else if (toolTip.Equals("Damage reduction 10%")){
            damageReduction += 0.1f;
        }else if (toolTip.Equals("Laser Beam Damage +10")){
            Beam.damage += 10f;
        }else if (toolTip.Equals("Laser Beam Speed and length +10%")){
            BeamController.speed *= 1.1f;
            BeamController.beamSize *= 1.1f;
        }else if (toolTip.Equals("Laser Beam Firerate + 10%")){
            TalentController.beamSpawnRate *= 1.1f;
        }else if (toolTip.Equals("XP gain +15%")){
            xpMultiplier *= 1.15f;
        }else if (toolTip.Equals("Mine Damage +10%")){
            Mine.damage *= 1.1f;
        }
        else if (toolTip.Equals("Mine Spawn Rate +10%")){
            TalentController.mineSpawnRate *= 1.1f;
        }
        else if (toolTip.Equals("Mine Explosion Radius +10%")){
            MineRadiusController.explosionRadius *= 1.1f;
        }
        else if (toolTip.Equals("Multishot +1 bullet")){
            TalentController.multiShotCount++;
        }
        else if (toolTip.Equals("Multishot damage +10%")){
            TalentController.bulletDamage *= 1.1f;
        }
        else if (toolTip.Equals("Multishot firerate +10%")){
            TalentController.multiShotFireRate *= 1.1f;
        }
    }

    public void HealthPickup(float amount){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        currHealth += amount;
        if (currHealth > maxHealth){
            currHealth = maxHealth;
        }
        pl.DisplayDamage(amount, new Color(0,100,0,1f));
        pl.playHealSound();
    }

    public void GainHealth(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        if (currHealth < maxHealth){
            currHealth += healthRegen;
            pl.DisplayDamage(healthRegen, new Color(0,100,0,1f));
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
        killCount++;
        currXp += amount* xpMultiplier;
        if (currXp >= xpRequired){
            levelUp();
        }
    }

}