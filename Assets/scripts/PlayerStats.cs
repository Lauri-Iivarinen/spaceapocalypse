public class PlayerStats{
    public int level = 1;
    public float speed = 1f;
    public int xpRequired = 150;

    public int currXp = 0;
    public float damageMultiplier = 1f;
    public int maxHealth = 100;
    public int currHealth = 100;
    public int mobsKilled = 0;

    public void levelUp(){
        level++;
        currXp = currXp-xpRequired;
        xpRequired = (int)((xpRequired + 100) * 1.1f);
        maxHealth += 10;
        currHealth += 10;
    }

    public void gainXp(int amount){
        currXp += amount;
        if (currXp >= xpRequired){
            levelUp();
        }
    }

}