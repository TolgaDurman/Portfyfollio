using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class JumpEvent : ObserverEvent
    {
        private List<Transform> jumpers = new List<Transform>(); 
        public override void OnEventExecute()
        {
            
        }
        public void AssignObservers(Transform jumper)
        {
            jumpers.Add(jumper);
        }
        public void RemoveObserver(Transform jumper)
        {
            if(jumpers.Contains(jumper))
                jumpers.Remove(jumper);
        }
    }
}
