using System;

[Serializable]
public class PermanentUpgrade
{
    public int index;
    public string name;
    public string tooltip;
    public float currAmount;
    public float maxAmount;
    public float buffIncrement;
    public int upgradeCost;
    public int costIncrement;
    public int maxUpgrades;
    public int currUpgrades = 0;

    public PermanentUpgrade(int index, string name, string tooltip, float currAmount, float maxAmount, float buffIncrement, int upgradeCost, int costIncrement) {
        this.name = name;
        this.tooltip = tooltip;
        this.currAmount = currAmount;
        this.maxAmount = maxAmount;
        this.buffIncrement = buffIncrement;
        this.upgradeCost = upgradeCost;
        this.costIncrement = costIncrement;
        this.index = index;

        maxUpgrades = (int)Math.Round((maxAmount - currAmount) / buffIncrement);

        //get db stats here:)
    }

    public void UpgradeStat()
    {
        if (currUpgrades < maxUpgrades && PermanentStats.currency >= upgradeCost)
        {
            currAmount += buffIncrement;
            PermanentStats.currency -= upgradeCost;
            upgradeCost += costIncrement;
            currUpgrades++;
            PermanentStats.upgrades[index] = this;
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
            PermanentStats.upgrades[index] = this;
        }
    }

    public int RefundAll()
    {
        if (currUpgrades > 0)
        {
            RefundStat();
            return RefundAll();
        }
        PermanentStats.upgrades[index] = this;
        return 0;
        
    }
}

public class PermanentStats
{
    public static int killCount = 0;
    public static int currency = 0;

    public static PermanentUpgrade damage = new PermanentUpgrade(0,"Damage", "Increse damage done by +3% per level.", 0f, 0.18f, 0.03f, 30, 45);
    public static PermanentUpgrade hp = new PermanentUpgrade(1,"Health", "Increase max health by 2% per level.", 1f, 1.1f, 0.02f, 20, 35);
    public static PermanentUpgrade hpRegen = new PermanentUpgrade(2,"Health Regen", "Increase passive health regeneration by + 0.25 hps per level.", 0f, 4f, 1f, 20, 35);
    public static PermanentUpgrade damageReduction = new PermanentUpgrade(3,"Damage Reduction", "Reduce damage taken by enemies by 5% per level.", 0f, 0.2f, 0.05f, 25, 35);
    public static PermanentUpgrade speed = new PermanentUpgrade(4,"Rocket Speed", "Increase rocket speed by 5% per level.", 0f, 0.2f, 0.05f, 25, 30);
    public static PermanentUpgrade xpGain = new PermanentUpgrade(5,"XP Gain", "Increases XP gained from eliminating enemies by 5% per level.", 0f, 0.15f, 0.05f, 25, 55);
    public static PermanentUpgrade atkSpeed = new PermanentUpgrade(6,"Attack Speed", "Increases default weapon attack speed by 5% per level.", 0f, 0.2f, 0.05f, 30, 45);
    public static PermanentUpgrade critChance = new PermanentUpgrade(7,"Crit Chance", "Increases chance to deal critical hits by 2% per level.", 0f, 0.1f, 0.02f, 30, 45);
    public static PermanentUpgrade critDamage = new PermanentUpgrade(8,"Crit Damage", "Increased critical damage done by 4% per level.", 1f, 1.2f, 0.04f, 30, 45);
    public static PermanentUpgrade boosterRate = new PermanentUpgrade(9,"Booster Rate", "Increases booster recharge rate.", 0f, 0.3f, 0.1f, 25, 20);
    public static PermanentUpgrade currencyGain = new PermanentUpgrade(10,"Currency Gain", "Increased parts gained from all sources by 10% per level.", 1f, 1.5f, 0.1f, 60, 65);
    public static PermanentUpgrade extraLives = new PermanentUpgrade(11,"Extra Life", "Gain 1 extra life per run.", 0f, 1f, 1f, 650, 1);
    public static PermanentUpgrade bulletPenetration = new PermanentUpgrade(12,"Bullet Penetration", "Increases base weapon penetration power by 20% per level.", 0f, 1f, 0.2f, 40, 55);

    public static PermanentUpgrade[] upgrades = { damage, hp, hpRegen, damageReduction, speed, xpGain, atkSpeed, critChance, critDamage, boosterRate, currencyGain, extraLives, bulletPenetration };
    //List<PermanentUpgrade> upgrades = new List<PermanentUpgrade>();

    public static int PrintStuff()
    {
        return upgrades[12].currUpgrades;
    }

    public static void refundUpgrades()
    {
        foreach (PermanentUpgrade upg in upgrades){
            upg.RefundAll();
        }
    }


    public static void InitDb()
    {
        
    }
}
