using System.Threading.Tasks;
using UnityEngine;

namespace PrototypePattern
{
    public class Sword : _Weapon
    {
        private float shootRate;
        private int ammoCapacity;
        private float reloadTime;

        private static int swordCount;

        public Sword(float shootRate, int ammoCapacity, float reloadTime)
        {
            this.shootRate = shootRate;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            swordCount++;
            return new Sword(shootRate, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            Shot();
        }

        private async void Shot()
        {
            await Task.Delay((int)(shootRate*1000));
            Debug.Log($"Sword{swordCount} attack!");
        }
    }
}
