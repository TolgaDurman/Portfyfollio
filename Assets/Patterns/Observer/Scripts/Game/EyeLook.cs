using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class EyeLook : MonoBehaviour
    {
        public Transform lookAt;

        private void LateUpdate()
        {
            transform.LookAt(lookAt);
        }
    }
}