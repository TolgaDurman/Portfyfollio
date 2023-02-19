using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlyweightPattern
{

    public class FlyweightTester : MonoBehaviour
    {
        private List<Heavyweight> HeavyweightObjects = new List<Heavyweight>();

        private List<Flyweight> flyweightObjects = new List<Flyweight>();
        public int numberOfObjects = 1000000;
        private bool isFlyweight = true;
        public TextMeshProUGUI displayText;
        private const string flyweightName = "FLYWEIGHT";
        private const string heavyweightName = "HEAVYWEIGHT";
        public void SwitchWeight()
        {
            isFlyweight = !isFlyweight;
            displayText.text = isFlyweight ? flyweightName : heavyweightName;
        }

        public void Test()
        {
            if (!isFlyweight)
            {
                GenerateHeavyweight();
            }
            else
            {
                GenerateFlyweight();
            }
        }
        private void GenerateHeavyweight()
        {
            //Generate Heavyweight objects that doesn't share any data
            for (int i = 0; i < numberOfObjects; i++)
            {
                Heavyweight newHeavyweight = new Heavyweight();

                HeavyweightObjects.Add(newHeavyweight);
            }
        }
        private void GenerateFlyweight()
        {
            //Generate the data that's being shared among all objects

            Data data = new Data();

            for (int i = 0; i < numberOfObjects; i++)
            {
                Flyweight newFlyweight = new Flyweight(data);

                flyweightObjects.Add(newFlyweight);
            }
        }
    }
}