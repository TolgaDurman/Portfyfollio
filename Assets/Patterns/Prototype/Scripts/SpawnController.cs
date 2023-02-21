using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypePattern
{
    public class SpawnController : MonoBehaviour
    {
        private Bomb bombPrototype;
        private Bow bowPrototype;
        private Gun gunPrototype;
        private Sword swordPrototype;

        private Spawner[] weaponSpawners;

        private void Start()
        {
            bombPrototype = new Bomb(damage: 0f, ammoCapacity: 1, reloadTime: 4f);
            bowPrototype = new Bow(damage: 1f, ammoCapacity: 4, reloadTime: 1f);
            gunPrototype = new Gun(damage: 0.2f, ammoCapacity: 12, reloadTime: 0.4f);
            swordPrototype = new Sword(damage: 2f, ammoCapacity: 0, reloadTime: 4f);

            weaponSpawners = new Spawner[4]
            {
                new Spawner(bombPrototype),
                new Spawner(bowPrototype),
                new Spawner(gunPrototype),
                new Spawner(swordPrototype)
            };
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) SpawnSword();
            
            //We can't use Unity's Instantiate method because those objects have to inherit from Object
            //Gun newGun = Instantiate(gunPrototype) as Gun;
        }
        public void SpawnSword()
        {
            _Weapon spawned = weaponSpawners[3].SpawnWeapon();
            spawned.Shoot();
        }
    }
}