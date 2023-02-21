namespace PrototypePattern
{
    public class Gun : _Weapon
    {
        private float shootRate;
        private int ammoCapacity;
        private float reloadTime;

        public Gun(float shootRate, int ammoCapacity, float reloadTime)
        {
            this.shootRate = shootRate;
            this.ammoCapacity = ammoCapacity;
            this.reloadTime = reloadTime;
        }

        public override _Weapon Clone()
        {
            return new Gun(shootRate, ammoCapacity, reloadTime);
        }

        public override void Shoot()
        {

        }
    }
}
