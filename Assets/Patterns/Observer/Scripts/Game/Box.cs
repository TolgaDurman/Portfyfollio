using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class Box : Observer
    {
        private GameObject gameObject;
        private BoxEvents observerEvent;

        public Box(GameObject gameObject, BoxEvents observerEvent)
        {
            this.gameObject = gameObject;
            this.observerEvent = observerEvent;
        }

        public override void OnNotify()
        {
            observerEvent.OnEventExecute();
        }
    }
}
