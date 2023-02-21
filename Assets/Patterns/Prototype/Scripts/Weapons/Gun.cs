namespace PrototypePattern
{
    public class Gun : _Weapon
    {
        private float damage;
        private int ammoCapacity;
        private float reloadTime;

        public Gun(float damage, int ammoCapacity, float reloadTime)
        {
            this.damage = damage;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Gun(damage, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {

        }
    }
}
