using UnityEngine;

namespace PrototypePattern
{
    public class Sword : _Weapon
    {
        private float damage;
        private int ammoCapacity;
        private float reloadTime;

        private static int swordCount;

        public Sword(float damage, int ammoCapacity, float reloadTime)
        {
            this.damage = damage;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            swordCount++;
            return new Sword(damage, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            Debug.Log($"Sword{swordCount} attack! damage = {damage} , ammo cap = {ammoCapacity}");
        }
    }
}
