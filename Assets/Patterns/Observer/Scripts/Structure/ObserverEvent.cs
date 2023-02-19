using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class ObserverEvent
    {
        public abstract void OnEventExecute();
    }
}
