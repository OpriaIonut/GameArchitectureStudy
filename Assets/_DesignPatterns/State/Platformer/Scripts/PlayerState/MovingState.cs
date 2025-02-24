using UnityEngine;

namespace DesignPatterns.State.Platformer
{
    public class MovingState : IState
    {
        private float moveSpeed = 750.0f;
        private float moveDir = 0.0f;
        private Transform transform;
        private Rigidbody2D rigidbody;

        public void OnEnter(Transform transf, Rigidbody2D rb)
        {
            moveDir = Input.GetAxis("Horizontal");
            transform = transf;
            rigidbody = rb;
        }

        public void OnExit()
        {
            
        }

        public IState HandleInput()
        {
            moveDir = Input.GetAxis("Horizontal");
            if (moveDir == 0.0f)
                return new IdleState();
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (rigidbody.linearVelocity.y == 0.0f))
                return new JumpingState();
            return this;
        }

        public IState UpdateState()
        {
            rigidbody.linearVelocity = new Vector2(moveDir * moveSpeed * Time.deltaTime, rigidbody.linearVelocity.y);
            return this;
        }
    }
}