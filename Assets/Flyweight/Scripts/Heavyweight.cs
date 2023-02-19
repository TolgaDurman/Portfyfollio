using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPattern
{
    //This class doesn't share any data among all objects
    public class Heavyweight
    {
        private float health;

        private Data data;


        public Heavyweight()
        {
            health = Random.Range(10f, 100f);

            data = new Data();
        }
    }
}