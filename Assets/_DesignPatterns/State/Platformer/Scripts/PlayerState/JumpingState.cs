using UnityEngine;

namespace DesignPatterns.State.Platformer
{
    public class JumpingState : IState
    {
        private float jumpForce = 500.0f;
        private Transform transform;
        private Rigidbody2D rigidbody;

        public void OnEnter(Transform transf, Rigidbody2D rb)
        {
            transform = transf;
            rigidbody = rb;
            rigidbody.AddForce(Vector2.up * jumpForce);
        }

        public void OnExit()
        {

        }

        public IState HandleInput()
        {
            if (Input.GetAxis("Horizontal") != 0.0f)
                return new MovingState();
            return this;
        }

        public IState UpdateState()
        {
            if (rigidbody.linearVelocity.y == 0.0f)
                return new IdleState();
            return this;
        }
    }
}