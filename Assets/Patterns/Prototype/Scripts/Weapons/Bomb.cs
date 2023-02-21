namespace PrototypePattern
{
    public class Bomb : _Weapon
    {
        private float shootRate;
        private int ammoCapacity;
        private float reloadTime;

        public Bomb(float shootRate, int ammoCapacity, float reloadTime)
        {
            this.shootRate = shootRate;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Bomb(shootRate, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            
        }
    }
}
