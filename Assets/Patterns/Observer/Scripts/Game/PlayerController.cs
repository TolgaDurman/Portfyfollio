using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 4f;
        private Rigidbody m_RigidBody;
        public Transform gfx_base;
        private float turnSmoothTime = 0.05f;
        private float turnSmoothVelocity;

        private Vector3 velocity = Vector3.zero;
        private void Awake()
        {
            m_RigidBody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.z = Input.GetAxisRaw("Vertical");

            if (velocity.magnitude > 0.0f)
            {
                float targetAngle = Mathf.Atan2(velocity.x,velocity.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(gfx_base.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
                gfx_base.rotation = Quaternion.Euler(0f,angle,0f);
            }
        }
        private void FixedUpdate()
        {
            m_RigidBody.MovePosition(transform.position + velocity.normalized * moveSpeed * Time.deltaTime);
        }
    }
}