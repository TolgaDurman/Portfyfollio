using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();

        //Send notifications if something has happened
        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                //Notify all observers even though some may not be interested in what has happened
                //Each observer should check if it is interested in this event
                observers[i].OnNotify();
            }
        }

        //Add observer to the list
        public void AddObservers(params Observer[] observer)
        {
            for (int i = 0; i < observer.Length; i++)
            {
                observers.Add(observer[i]);
            }
        }

        //Remove observer from the list
        public void RemoveObserver(Observer observer)
        {

        }
    }
}