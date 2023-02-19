using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObserverPattern
{
    public class AllButton : MonoBehaviour
    {
        public ObserverPattern.Button[] buttons;
        public Cable[] m_cables;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < m_cables.Length; i++)
                {
                    m_cables[i].SendEvent(null);
                }
                StartCoroutine(PressAll());
            }
        }
        private IEnumerator PressAll()
        {
            yield return new WaitForSeconds(m_cables[0].sendTime);
            foreach (var item in buttons)
            {
                item.Pressed();
            }
        }
    }
}