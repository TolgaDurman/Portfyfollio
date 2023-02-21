namespace PrototypePattern
{
    public class Bomb : _Weapon
    {
        private float damage;
        private int ammoCapacity;
        private float reloadTime;

        public Bomb(float damage, int ammoCapacity, float reloadTime)
        {
            this.damage = damage;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Bomb(damage, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            
        }
    }
}
