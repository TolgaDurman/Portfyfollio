using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 4f;
        private Rigidbody m_RigidBody;

        private Vector3 velocity = Vector3.zero;
        private void Awake()
        {
            m_RigidBody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.z = Input.GetAxisRaw("Vertical");
        }
        private void FixedUpdate()
        {
            m_RigidBody.MovePosition(transform.position + velocity.normalized * moveSpeed * Time.deltaTime);
        }
    }
}