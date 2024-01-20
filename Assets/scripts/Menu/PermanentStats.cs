using System;
using System.Collections.Generic;

public class PermanentUpgrade
{
    public string name;
    public string tooltip;
    public float currAmount;
    public float maxAmount;
    public float buffIncrement;
    public int upgradeCost;
    public int costIncrement;
    public int maxUpgrades;
    public int currUpgrades = 0;

    public PermanentUpgrade(string name, string tooltip, float currAmount, float maxAmount, float buffIncrement, int upgradeCost, int costIncrement) {
        this.name = name;
        this.tooltip = tooltip;
        this.currAmount = currAmount;
        this.maxAmount = maxAmount;
        this.buffIncrement = buffIncrement;
        this.upgradeCost = upgradeCost;
        this.costIncrement = costIncrement;

        maxUpgrades = (int)Math.Round((maxAmount - currAmount) / buffIncrement);

        //get db stats here:)
    }

    public void UpgradeStat()
    {
        if (currUpgrades < maxUpgrades && PermanentStats.currency > upgradeCost)
        {
            currAmount += buffIncrement;
            PermanentStats.currency -= upgradeCost;
            upgradeCost += costIncrement;
            currUpgrades++;
        }
    }

    public void RefundStat()
    {
        if (currUpgrades > 0)
        {
            currAmount -= buffIncrement;
            upgradeCost -= costIncrement;
            PermanentStats.currency += upgradeCost;
            currUpgrades--;
        }
    }

    public int RefundAll()
    {
        if (currUpgrades > 0)
        {
            RefundStat();
            return RefundAll();
        }
        return 0;
    }
}

public class PermanentStats
{
    public static int killCount = 0;
    public static int currency = 9999;

    public static PermanentUpgrade damage = new PermanentUpgrade("Damage", "Increse damage done by +3% per level.", 0f, 0.18f, 0.03f, 1, 1);
    public static PermanentUpgrade hp = new PermanentUpgrade("Health", "Increase max health by 2% per level.", 1f, 1.1f, 0.02f, 1, 1);
    public static PermanentUpgrade hpRegen = new PermanentUpgrade("Health Regen", "Increase passive health regeneration by + 0.25 hps per level.", 0f, 4f, 1f, 1, 1);
    public static PermanentUpgrade damageReduction = new PermanentUpgrade("Damage Reduction", "Reduce damage taken by enemies by 5% per level.", 0f, 0.2f, 0.05f, 1, 1);
    public static PermanentUpgrade speed = new PermanentUpgrade("Rocket Speed", "Increse rocket speed by 5% per level.", 0f, 0.2f, 0.05f, 1, 1);
    public static PermanentUpgrade xpGain = new PermanentUpgrade("XP Gain", "Increases XP gained from eliminating enemies by 5% per level.", 0f, 0.15f, 0.05f, 1, 1);
    public static PermanentUpgrade atkSpeed = new PermanentUpgrade("Attack Speed", "Increses default weapon attack speed by 5% per level.", 0f, 0.2f, 0.05f, 1, 1);
    public static PermanentUpgrade critChance = new PermanentUpgrade("Crit Chance", "Increses chance to deal critical hits by 2% per level.", 0f, 0.1f, 0.02f, 1, 1);
    public static PermanentUpgrade critDamage = new PermanentUpgrade("Crit Damage", "Incresed critical damage done by 4% per level.", 1f, 1.2f, 0.04f, 1, 1);
    public static PermanentUpgrade boosterRate = new PermanentUpgrade("Booster Rate", "Increses booster recharge rate.", 0f, 0.3f, 0.1f, 1, 1);
    public static PermanentUpgrade currencyGain = new PermanentUpgrade("Currency Gain", "Incresed XXXX gained from all sources by 10% per level.", 1f, 1.5f, 0.1f, 1, 1);
    public static PermanentUpgrade extraLives = new PermanentUpgrade("Extra Life", "Gain 1 extra life per run.", 0f, 1f, 1f, 1, 1);
    public static PermanentUpgrade bulletPenetration = new PermanentUpgrade("Bullet Penetration", "Increses base weapon penetration power by 20% per level.", 0f, 1f, 0.2f, 1, 1);

    public static PermanentUpgrade[] upgrades = { damage, hp, hpRegen, damageReduction, speed, xpGain, atkSpeed, critChance, critDamage, boosterRate, currencyGain, extraLives, bulletPenetration };
    //List<PermanentUpgrade> upgrades = new List<PermanentUpgrade>();

    public static void refundUpgrades()
    {
        foreach (PermanentUpgrade upg in upgrades){
            upg.RefundAll();
        }
    }
}
