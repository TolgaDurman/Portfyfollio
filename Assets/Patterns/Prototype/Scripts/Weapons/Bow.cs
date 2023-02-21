namespace PrototypePattern
{
    public class Bow : _Weapon
    {
        private float shootRate;
        private int ammoCapacity;
        private float reloadTime;

        public Bow(float shootRate, int ammoCapacity, float reloadTime)
        {
            this.shootRate = shootRate;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Bow(shootRate, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {
            
        }
    }
}
