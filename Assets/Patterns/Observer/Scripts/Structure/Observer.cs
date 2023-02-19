using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer
    {
        public abstract void OnNotify(ObserverEvent observedEvent);
    }
}
