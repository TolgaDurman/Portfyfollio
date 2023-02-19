using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class Box : Observer
    {
        private ObserverEvent observedEvent;

        public Box(ObserverEvent observedEvent)
        {
            this.observedEvent = observedEvent;
        }

        public override void OnNotify(ObserverEvent observedEvent)
        {
            
        }
    }
}
