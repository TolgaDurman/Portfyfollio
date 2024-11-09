using UnityEngine;

namespace FPCharacterPhysics
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float moveSpeed = 5f;
        public float jumpForce = 5f;
        public float lookSpeed = 2f;
    }
}