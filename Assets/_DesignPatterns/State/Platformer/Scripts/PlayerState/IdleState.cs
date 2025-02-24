using UnityEngine;

namespace DesignPatterns.State.Platformer
{
    public class IdleState : IState
    {
        private Transform transform;
        private Rigidbody2D rigidbody;

        public void OnEnter(Transform transf, Rigidbody2D rb)
        {
            transform = transf;
            rigidbody = rb;
        }

        public void OnExit()
        {

        }

        public IState HandleInput()
        {
            if (Input.GetAxis("Horizontal") != 0.0f)
                return new MovingState();
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (rigidbody.linearVelocity.y == 0.0f))
                return new JumpingState();
            return this;
        }

        public IState UpdateState()
        {
            return this;
        }
    }
}