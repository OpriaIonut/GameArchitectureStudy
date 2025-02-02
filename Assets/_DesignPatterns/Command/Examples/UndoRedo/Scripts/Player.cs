using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private Platform startingPlatform;

        private float health;
        private Platform currentPlatform;

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Start()
        {
            health = maxHealth;
            currentPlatform = startingPlatform;

            InputHandler input = Locator.GetService<InputHandler>();
            MovementCommandInvoker commandInvoker = Locator.GetService<MovementCommandInvoker>();
            input.AddListener_upBtnPress(() => { commandInvoker.ExecuteCommand(new MovementCommand(this, MoveDirection.Up)); });
            input.AddListener_downBtnPress(() => { commandInvoker.ExecuteCommand(new MovementCommand(this, MoveDirection.Down)); });
            input.AddListener_leftBtnPress(() => { commandInvoker.ExecuteCommand(new MovementCommand(this, MoveDirection.Left)); });
            input.AddListener_rightBtnPress(() => { commandInvoker.ExecuteCommand(new MovementCommand(this, MoveDirection.Right)); });
        }

        public void Heal(float ammount)
        {
            health = Mathf.Clamp(health + ammount, 0.0f, maxHealth);
        }

        public void TakeDamage(float ammount)
        {
            health = Mathf.Clamp(health - ammount, 0.0f, maxHealth);
        }

        public bool IsValidMove(MoveDirection direction)
        {
            PlatformSpawner spawner = Locator.GetService<PlatformSpawner>();
            return spawner.DoesPlatformExistInDir(currentPlatform, direction);
        }

        public void Move(MoveDirection direction)
        {
            PlatformSpawner spawner = Locator.GetService<PlatformSpawner>();
            currentPlatform = spawner.GetPlatformByDirection(currentPlatform, direction);
            transform.position = currentPlatform.transform.position;
        }
    }
}