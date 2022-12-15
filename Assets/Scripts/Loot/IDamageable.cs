using CrashedWorld.Items;

public interface IDamageable
{
    public void TryDamage(int targetDamage, WeaponTypes weaponType);
}
