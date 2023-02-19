using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    public class Flyweight
    {
        //Data for each individual object
        private float health;

        //Shared data
        private Data data;

        public Flyweight(Data data)
        {
            health = Random.Range(10f, 100f);
            
            this.data = data;
        }
    }
}
