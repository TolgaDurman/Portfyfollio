using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObserverPattern
{
    public class Button : MonoBehaviour
    {
        public int myIndex;
        public UnityEvent<int> OnPress;
        public Cable m_cable;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Pressed();
        }
        public void Pressed()
        {
            m_cable.SendEvent(() => OnPress?.Invoke(myIndex));
        }
    }
}