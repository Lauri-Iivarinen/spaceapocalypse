public class ClassSpecs
{
    public string className;
    public float weaponDamage;
    public int magSize;
    public float fireRate;
    public int projectileLifetime;
    public int penetration = 1;
    public float projectileSpeed = 10.0f;
    public float rocketSpeed;
    public int rocketHealth;

    public ClassSpecs(string name, float damage, int magSize, float fireRate, int lifetime, int penetration, float projectileSpeed, float rocketSpeed, int hp)
    {
        this.className = name;
        this.weaponDamage = damage;
        this.magSize = magSize;
        this.fireRate = fireRate;
        this.projectileLifetime = lifetime;
        this.penetration = penetration;
        this.projectileSpeed = projectileSpeed;
        this.rocketSpeed = rocketSpeed;
        this.rocketHealth = hp;
    }
}

