using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class Mover : MonoBehaviour
    {
        public WaitForSeconds waitTime;
        public float moveCompleteTime = 1f;
        public AnimationCurve ease;
        private float easeTime;
        private Vector2Int currentPos;
        public Vector2Int CurrentPos
        {
            get => currentPos;
        }
        private void Awake()
        {
            waitTime = new WaitForSeconds(moveCompleteTime);
        }

        public void MoveUp()
        {
            StartCoroutine(MoveToPosition(Vector3.up));
            currentPos.y += 1;
        }
        public void MoveDown()
        {
            StartCoroutine(MoveToPosition(Vector3.down));
            currentPos.y -= 1;
        }
        public void MoveLeft()
        {
            StartCoroutine(MoveToPosition(Vector3.left));
            currentPos.x -= 1;
        }
        public void MoveRight()
        {
            StartCoroutine(MoveToPosition(Vector3.right));
            currentPos.x += 1;
        }
        public void ResetPosition()
        {
            currentPos = new Vector2Int();
        }

        /// <summary>
        /// Move with ease
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public IEnumerator MoveToPosition(Vector3 direction)
        {
            GameManager.canInputGet = GameManager.isReplaying ? false : false;
            float setTime = 0f;
            Vector3 startPos = transform.position;
            while (setTime < moveCompleteTime)
            {
                setTime += Time.deltaTime;
                easeTime = Mathf.Lerp(0f, 1f, setTime);
                transform.position = startPos + direction * ease.Evaluate(setTime / moveCompleteTime);
                yield return null;
            }
            GameManager.canInputGet = GameManager.isReplaying ? false : true;
        }
    }
}