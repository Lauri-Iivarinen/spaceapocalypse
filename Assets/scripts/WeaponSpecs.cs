public class WeaponSpecs
{
    public string weaponName;
    public float weaponDamage;
    public int magSize;
    public float fireRate;
    public int projectileLifetime;
    public int penetration = 1;
    public float projectileSpeed = 10.0f;

    public WeaponSpecs(string name, float damage, int magSize, float fireRate, int lifetime, int penetration, float speed)
    {
        this.weaponName = name;
        this.weaponDamage = damage;
        this.magSize = magSize;
        this.fireRate = fireRate;
        this.projectileLifetime = lifetime;
        this.penetration = penetration;
        this.projectileSpeed = speed;
    }
}

