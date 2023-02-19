using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObserverPattern
{
    public class Cable : MonoBehaviour
    {
        public Transform eventDisplayPrefab;
        public Vector3 startPos,endPos;
        public float sendTime = 0.4f;

        public void SendEvent(UnityAction onComplete)
        {
            StartCoroutine(SendEventEnum(onComplete));
        }

        private IEnumerator SendEventEnum(UnityAction onComplete)
        {
            float currentTime = 0f;
            Transform spawned =Instantiate(eventDisplayPrefab,startPos,Quaternion.identity,transform);
            spawned.localEulerAngles = Vector3.zero;
            while (currentTime < sendTime)
            {
                currentTime += Time.deltaTime;
                spawned.transform.localPosition = Vector3.Lerp(startPos,endPos,currentTime / sendTime);
                yield return null;
            }
            onComplete?.Invoke();
            Destroy(spawned.gameObject);
        }
    }
}