using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameManager : MonoBehaviour
    {
        public GameObject box1;
        public GameObject box2;
        public GameObject box3;
        private Subject jump1Subject = new Subject();
        private Subject jump2Subject = new Subject();
        private Subject jump3Subject = new Subject();
        private void Start()
        {
            Box box1Obs = new Box(box1.gameObject, new JumpEvent(box1.GetComponent<Rigidbody>()));
            Box box2Obs = new Box(box2.gameObject, new JumpEvent(box2.GetComponent<Rigidbody>()));
            Box box3Obs = new Box(box3.gameObject, new JumpEvent(box3.GetComponent<Rigidbody>()));
            jump1Subject.AddObservers(box1Obs);
            jump2Subject.AddObservers(box2Obs);
            jump3Subject.AddObservers(box3Obs);
        }

        public void NotifyBox(int index)
        {
            switch (index)
            {
                case 1:
                    jump1Subject.Notify();
                    break;
                case 2:
                    jump2Subject.Notify();
                    break;
                case 3:
                    jump3Subject.Notify();
                    break;
                default:
                Debug.Log($"{index}: Index doesn't exists");
                    break;
            }
        }
        public void NotifyAllSubjects()
        {
            jump1Subject.Notify();
            jump2Subject.Notify();
            jump3Subject.Notify();
        }
    }
}
