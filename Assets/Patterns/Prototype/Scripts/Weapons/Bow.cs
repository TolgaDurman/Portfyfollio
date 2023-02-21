namespace PrototypePattern
{
    public class Bow : _Weapon
    {
        private float damage;
        private int ammoCapacity;
        private float reloadTime;

        public Bow(float damage, int ammoCapacity, float reloadTime)
        {
            this.damage = damage;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Bow(damage, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            
        }
    }
}
