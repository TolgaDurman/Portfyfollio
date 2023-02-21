namespace PrototypePattern
{
    public class Spawner
    {
        private _Weapon weapon;

        public Spawner(_Weapon weapon)
        {
            this.weapon = weapon;
        }

        public _Weapon SpawnWeapon()
        {
            return weapon.Clone();
        }
    }
}