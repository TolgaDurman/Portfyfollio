using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class AutoRotation : MonoBehaviour
    {
        public Vector3 rotateTowards = new Vector3(0,360,0);
        public AnimationCurve ease;
        private float easeTime;
        public float completeTime;
        public bool looping;

        private void Start()
        {
            StartCoroutine(AnimateRotation());
        }
        private IEnumerator AnimateRotation()
        {
            float setTime = 0f;
            Vector3 startRot = transform.localEulerAngles;
            while (setTime < completeTime)
            {
                setTime += Time.deltaTime;
                easeTime = Mathf.Lerp(0f, 1f, setTime);
                transform.localEulerAngles = startRot + rotateTowards * ease.Evaluate(setTime / completeTime);
                yield return null;
            }
            if(looping)
                StartCoroutine(AnimateRotation());
        }

    }
}
