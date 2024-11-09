using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPCharacterPhysics
{
    // Player must have controls, camera, and movement
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public PlayerSettings PlayerSettings { get; private set; }
        [field: SerializeField] public Rigidbody PhysicsBody { get; private set; }

        private readonly Dictionary<Type, IPlayerModule> playerModules = new Dictionary<Type, IPlayerModule>
        {
            { typeof(PlayerControls), new PlayerControls() },
            { typeof(CharacterMovement), new CameraController() },
            { typeof(CameraController), new CharacterMovement() }
        };

        private void Awake()
        {
            foreach (var playerComponent in playerModules.Values)
            {
                playerComponent.InjectPlayer(this);
            }
        }

        #region ModuleExecution

        private void Update()
        {
            foreach (var module in playerModules)
            {
                if (module.Value is ITickModule tickModule)
                {
                    tickModule.Tick(Time.deltaTime);
                }
            }
        }

        #endregion

        #region Input

        public void OnMove(InputValue value)
        {
            if (TryGetPlayerModule<PlayerControls>(out var playerControls))
            {
                playerControls.OnMove(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            if (TryGetPlayerModule<PlayerControls>(out var playerControls))
            {
                playerControls.OnJump(value.isPressed);
            }
        }

        #endregion

        #region Modules

        public bool TryGetPlayerModule<T>(out T playerComponent) where T : class, IPlayerModule
        {
            playerComponent = GetPlayerModule<T>();
            return playerComponent != null;
        }

        private T GetPlayerModule<T>() where T : class, IPlayerModule
        {
            return playerModules[typeof(T)] as T;
        }

        #endregion
    }

    public sealed class PlayerControls : IPlayerModule
    {
        private Player player;
        public event Action<Vector2> Move = delegate { };
        public event Action<bool> Jump = delegate { };

        public void InjectPlayer(Player playerComponent)
        {
            player = playerComponent;
        }

        public void OnMove(Vector2 value)
        {
            Move(value);
        }

        public void OnJump(bool value)
        {
            Jump(value);
        }
    }

    public sealed class CharacterMovement : IPlayerModule, ITickModule
    {
        private Player player;
        private Rigidbody physicsBody;
        private Vector2 moveDirection;

        public void InjectPlayer(Player playerComponent)
        {
            player = playerComponent;
            if (player.TryGetPlayerModule<PlayerControls>(out var playerControls))
            {
                playerControls.Move += Move;
                playerControls.Jump += Jump;
            }

            if (player.PhysicsBody)
            {
                physicsBody = player.PhysicsBody;
            }
        }

        private void Move(Vector2 value)
        {
            moveDirection = value;
        }

        private void Jump(bool value)
        {
            if (value)
                physicsBody.AddForce(Vector3.up * player.PlayerSettings.jumpForce, ForceMode.Impulse);
        }

        public void Tick(float deltaTime)
        {
            var move = new Vector3(moveDirection.x, 0, moveDirection.y);
            move = player.transform.TransformDirection(move);
            var movement = physicsBody.position + move * (player.PlayerSettings.moveSpeed * deltaTime);
            physicsBody.MovePosition(movement);
        }
    }

    public sealed class CameraController : IPlayerModule
    {
        private Player player;

        public void InjectPlayer(Player playerComponent)
        {
            player = playerComponent;
        }
    }
}